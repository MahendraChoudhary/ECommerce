using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ECommerce.IdentityServer.Identity
{
    public class UserProfileService : IProfileService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserProfileService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = _userManager.GetUserAsync(context.Subject).Result;
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.GivenName, user.FirstName),
                new Claim(IdentityServerConstants.StandardScopes.Email, user.Email),
                new Claim("uid", user.Id),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            context.IssuedClaims.AddRange(claims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _userManager.GetUserAsync(context.Subject).Result;
            context.IsActive = user != null;
            return Task.FromResult(0);
        }
    }
}