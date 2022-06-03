using Microsoft.AspNetCore.Identity;

namespace ECommerce.IdentityServer.Identity
{
    public class TokenService : IUserTwoFactorTokenProvider<IdentityUser>
    {
        public Task<bool> CanGenerateTwoFactorTokenAsync
            (UserManager<IdentityUser> manager, IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateAsync
            (string purpose, UserManager<IdentityUser> manager, IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateAsync
            (string purpose, string token, UserManager<IdentityUser> manager, IdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
