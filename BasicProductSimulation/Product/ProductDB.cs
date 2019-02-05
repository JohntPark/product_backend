using Microsoft.EntityFrameworkCore;

namespace BasicProductSimulation
{
    public class ProductDB : DbContext
    {
        public ProductDB(DbContextOptions<ProductDB> options)
            :base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
