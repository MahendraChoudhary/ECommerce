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
        private readonly UserManager<IdentityUser> _userManager;

        public Register(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterUser user)
        {
            var identityUser = user.GetIdentityUser();
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(identityUser, Constants.Roles["Customer"]);
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}
