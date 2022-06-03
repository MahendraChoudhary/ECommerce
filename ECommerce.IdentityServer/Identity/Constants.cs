namespace ECommerce.IdentityServer.Identity
{
    public class Constants
    {
        public static Dictionary<string, string> Roles =>
             new Dictionary<string, string>
             {
                {"Customer", "Customer" },
                {"Seller", "Seller" }
             };
    }
}
