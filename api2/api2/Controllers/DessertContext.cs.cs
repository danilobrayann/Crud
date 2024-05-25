using api2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DessertAPI.Data;
using DessertAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api2.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
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
    public async Task<ActionResult<Dessert>> GetDessert(int id)
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
