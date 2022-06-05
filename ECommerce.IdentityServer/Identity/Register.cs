using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.IdentityServer.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class Register : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public Register(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("{isSeller}")]
        public async Task<ActionResult> RegisterUser(RegisterUser user, bool isSeller = false)
        {
            var AppUser = user.GetAppUser();
            var result = await _userManager.CreateAsync(AppUser, user.Password);
            if (result.Succeeded)
            {
                var roles = new List<string> { Constants.Roles["Customer"] };
                if (isSeller)
                    roles.Add(Constants.Roles["Seller"]);

                await _userManager.AddToRolesAsync(AppUser, roles);
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}
