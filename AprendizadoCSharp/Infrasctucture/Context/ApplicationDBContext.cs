using AprendizadoCSharp.Domain.Stocks.Models;
using Microsoft.EntityFrameworkCore;

namespace AprendizadoCSharp.Infrasctucture.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
         
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
