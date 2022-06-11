using ECommerce.IdentityServer.Db;
using ECommerce.IdentityServer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ECommerce.IdentityServer.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<IdentityDb>();

                foreach (string role in Constants.Roles.Values)
                {
                    var roleStore = new RoleStore<IdentityRole>(dbContext);

                    if (!dbContext.Roles.Any(r => r.Name == role))
                    {
                        roleStore.CreateAsync(new IdentityRole(role));
                    }
                }

                dbContext.SaveChanges();
            }
        }
    }
}
