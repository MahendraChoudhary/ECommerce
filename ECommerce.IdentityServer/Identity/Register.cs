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

        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterUser user)
        {
            var AppUser = user.GetAppUser();
            var result = await _userManager.CreateAsync(AppUser, user.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(AppUser, Constants.Roles["Customer"]);
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}
