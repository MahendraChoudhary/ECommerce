using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.IdentityServer.Db
{
    public class IdentityDb : IdentityDbContext<AppUser>
    {
        public IdentityDb(DbContextOptions<IdentityDb> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
