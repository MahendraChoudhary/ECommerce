namespace ECommerce.TestClient
{
    internal class DataStore
    {
        private static bool useProduction = true;

        public class IdentityServer
        {
            private static string localUrl = "https://localhost:7124/";
            private static string prodUrl = "https://e-commerce-ids.herokuapp.com/";

            public static string Url
                => useProduction ? prodUrl : localUrl;
        }


        public static string Token { get; set; }
    }
}
