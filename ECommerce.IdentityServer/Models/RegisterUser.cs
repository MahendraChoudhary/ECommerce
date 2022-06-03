using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.IdentityServer.Models
{
    public class RegisterUser
    {

        [DataType(DataType.EmailAddress, ErrorMessage = "Please provide valid email address"), Required()]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Please provide valid email address"), Required()]
        public string Password { get; set; }

        [Required()]
        public string FirstName { get; set; }

        public IdentityUser GetIdentityUser()
        {
            return new IdentityUser()
            {
                Email = this.Email,
                UserName = this.Email,
            };
        }
    }
}
