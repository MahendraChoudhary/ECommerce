namespace ECommerce.Api.Orders.Db
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
