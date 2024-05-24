using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CategoriaController : ControllerBase
  {
    
    public CategoriaController()
    {
      
    }

    [HttpPost(Name = "GetWeatherForecast")]
    public Categoria Get([FromBody] Categoria categoria)
    {
      return categoria;
     
    }
  }
}
