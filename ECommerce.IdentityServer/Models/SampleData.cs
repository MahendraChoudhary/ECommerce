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
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                foreach (string role in Constants.Roles.Values)
                {

                    if (!(roleManager.RoleExistsAsync(role).Result))
                    {
                        roleManager.CreateAsync(new IdentityRole
                        {
                            Name = role,
                            NormalizedName= role,
                        });
                    }
                }
            }
        }
    }
}
