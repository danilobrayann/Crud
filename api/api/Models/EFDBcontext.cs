using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace api.Models
{
  public class EFDBcontext: DbContext

    public DbSet<Categoria> Categoria   { get; set; }
 


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseMemoryCache(@"Server=(localdb)\mssqllocaldb;Database=Test;ConnectRetryCount=0");
  }
}

  

