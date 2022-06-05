using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace ECommerce.Api.Customers.Services
{
    public class UserService
    {
        private readonly HttpContext httpContext;

        public UserService(IHttpContextAccessor contextAccessor)
        {
            httpContext = contextAccessor.HttpContext;
        }

        public Guid UserId
        {
            get
            {
                var uidClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == "uid");
                if (uidClaim == null)
                    throw new System.Exception("UnAuthorized user");

                if (Guid.TryParse(uidClaim.Value, out Guid uid))
                    return uid;

                throw new System.Exception("UnAuthorized user");
            }
        }
    }
}
