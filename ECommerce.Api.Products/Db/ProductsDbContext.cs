namespace ECommerce.Api.Products.Db
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
