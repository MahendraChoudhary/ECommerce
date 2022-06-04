using IdentityModel.Client;

namespace ECommerce.TestClient
{
    internal class AuthenticationUtility
    {

        private static bool useProd = false;
        private const string LocalIds = "https://localhost:7124/connect/token";
        private const string ProdIds = "https://e-commerce-ids.herokuapp.com/connect/token";

        public static void Login()
        {
            var client = new HttpClient() { Timeout = TimeSpan.FromMinutes(5) };
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = useProd? ProdIds : LocalIds,
                ClientId = "ECommerceApp",
                Scope = "customer",
                UserName = "mahi@example.com",
                Password = "Test@123"
            }).Result;
        }
    }
}
