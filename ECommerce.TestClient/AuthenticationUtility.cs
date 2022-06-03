using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TestClient
{
    internal class AuthenticationUtility
    {
        public static void Login()
        {
            var client = new HttpClient() { Timeout = TimeSpan.FromMinutes(5) };
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = "https://localhost:7124/connect/token",
                ClientId = "ECommerceApp",
                Scope = "customer",
                UserName = "user@example.com",
                Password = "Test@123"
            }).Result;
        }
    }
}
