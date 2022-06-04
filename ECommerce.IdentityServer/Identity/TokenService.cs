using Microsoft.AspNetCore.Identity;

namespace ECommerce.IdentityServer.Identity
{
    public class TokenService : IUserTwoFactorTokenProvider<AppUser>
    {
        public Task<bool> CanGenerateTwoFactorTokenAsync
            (UserManager<AppUser> manager, AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateAsync
            (string purpose, UserManager<AppUser> manager, AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateAsync
            (string purpose, string token, UserManager<AppUser> manager, AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
