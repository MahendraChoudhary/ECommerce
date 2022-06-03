using IdentityServer4.Models;

namespace ECommerce.IdentityServer.Identity
{
    public class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("customer")
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("customer", "The customer API.")
                {
                    Scopes={"customer"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "ECommerceApp",
                    AllowedScopes =
                    {
                        "openid",
                        "email",
                        "customer"
                    },
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    RequirePkce= true,
                    RequireClientSecret=false,
                    Enabled= true,
                    RequireConsent=false
                }
            };
    }
}
