using IdentityModel.Client;
using System.Net.Http.Json;

namespace ECommerce.TestClient
{
    internal class AuthenticationUtility
    {

        public static bool Login(string? userName, string? password)
        {
            var client = new HttpClient() { Timeout = TimeSpan.FromMinutes(5) };
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = DataStore.IdentityServer.Url + "connect/token",
                ClientId = "ECommerceApp",
                Scope = "customer",
                UserName = userName,
                Password = password
            }).Result;

            if (response.IsError)
            {
                Console.WriteLine($"Failed to login. Error: {response.Error}");
                return false;
            }
            else
            {
                Console.WriteLine("Logged in successfully.");
                DataStore.Token = response.AccessToken;
            }

            return true;
        }

        public static void Register()
        {
            Console.Write("Email id:");
            var emailId = Console.ReadLine();
            Console.Write("Password:");
            var password = Console.ReadLine();
            Console.Write("Firstname:");
            var firstName = Console.ReadLine();
            var client = new HttpClient() { Timeout = TimeSpan.FromMinutes(5) };
            var response
                = client.PostAsJsonAsync(DataStore.IdentityServer.Url + "api/Register",
                new { Email = emailId, Password = password, FirstName = firstName }).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Registered successfully.");
            }
            else
            {
                Console.WriteLine("Registered failed. Reason phrase: " 
                    + response.ReasonPhrase);
            }
        }
    }
}
