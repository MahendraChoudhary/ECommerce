namespace ECommerce.Api.Products.Db
{
    using Microsoft.EntityFrameworkCore;

    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
