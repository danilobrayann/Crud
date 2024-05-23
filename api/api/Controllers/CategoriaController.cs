using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CategoriaController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
          "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
      };

    private readonly EFDBcontext _dbContext;

    public CategoriaController(EFDBcontext dbContext)
    {
      _dbContext = dbContext;
    }

    [HttpPost()]
    public Categoria Post([FromBody] Categoria categoria)
    {
      _dbContext.Categoria.AddRange(categoria);
      _dbContext.SaveChanges();
      return categoria;
    }
  }
}
