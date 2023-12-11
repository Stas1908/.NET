using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4;

namespace Server
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new[]
            {
                new ApiScope("OrderApi.read"),
                new ApiScope("OrderApi.write")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("OrderApi")
                {
                    Scopes = new List<string> {"OrderApi.read","OrderApi.write" },
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="order",
                    ClientName="Swagger for Order Api",
                    ClientSecrets={new Secret("orderSecret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Code,
                    RequirePkce=true,
                    RedirectUris={ "https://localhost:7170/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins={"https://localhost:7170"},
                    AllowOfflineAccess=true,
                    AllowedScopes={
                        "openid",
                        "profile",
                        "OrderApi.read",
                        "OrderApi.write"
                    }
                }
            };
    }
}
