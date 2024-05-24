using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace API.Models
{
  public class BloggingContext : DbContext
  {
    public DbSet<Categoria> categoria { get; set; }
   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
          @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0");
    }
  }
}
