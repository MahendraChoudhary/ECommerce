namespace ECommerce.Api.Orders.Db
{
    using Microsoft.EntityFrameworkCore;

    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
