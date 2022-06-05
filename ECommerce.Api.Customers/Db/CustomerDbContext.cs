namespace ECommerce.Api.Customers.Db
{
    using Microsoft.EntityFrameworkCore;

    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
