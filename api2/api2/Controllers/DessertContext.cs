using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DessertApi
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DessertContext>(opt => opt.UseSqlite("Data Source=desserts.db"));
      services.AddCors(options =>
      {
        options.AddPolicy("AllowAll", builder =>
        {
          builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
        });
      });
      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors("AllowAll");

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }

    public class Dessert
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public int Calories { get; set; }
      public float Fat { get; set; }
      public int Carbs { get; set; }
      public float Protein { get; set; }
    }

    public class DessertContext : DbContext
    {
      public DessertContext(DbContextOptions<DessertContext> options) : base(options) { }

      public DbSet<Dessert> Desserts { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class DessertsController : ControllerBase
    {
      private readonly DessertContext _context;

      public DessertsController(DessertContext context)
      {
        _context = context;
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<Dessert>>> GetDesserts()
      {
        return await _context.Desserts.ToListAsync();
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<Dessert?>> GetDessert(int id)
      {
        var dessert = await _context.Desserts.FindAsync(id);
        if (dessert == null)
        {
          return NotFound();
        }
        return dessert;
      }

      [HttpPost]
      public async Task<ActionResult<Dessert>> PostDessert(Dessert dessert)
      {
        _context.Desserts.Add(dessert);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDessert), new { id = dessert.Id }, dessert);
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> PutDessert(int id, Dessert dessert)
      {
        if (id != dessert.Id)
        {
          return BadRequest();
        }

        _context.Entry(dessert).State = EntityState.Modified;

        try
        {
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!DessertExists(id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }

        return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteDessert(int id)
      {
        var dessert = await _context.Desserts.FindAsync(id);
        if (dessert == null)
        {
          return NotFound();
        }

        _context.Desserts.Remove(dessert);
        await _context.SaveChangesAsync();

        return NoContent();
      }

      private bool DessertExists(int id)
      {
        return _context.Desserts.Any(e => e.Id == id);
      }
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
