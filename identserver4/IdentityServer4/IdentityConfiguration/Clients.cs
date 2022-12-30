using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4.IdentityConfiguration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            //create some test clients
            return new List<Client>
            {
                new Client
                {
                    ClientId = "secretID",
                    ClientName = "ASP.NET secret Api",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("Clientsecret".Sha256())},
                    AllowedScopes = new List<string> {"secretApi.read"}
                },
                new Client
                {
                    ClientId = "secretID2",
                    ClientName = "ASP.NET Web App",
                    ClientSecrets = new List<Secret> {new Secret("Clientsecret2".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris =  {"https://localhost:44346/signin-oidc"},
                    FrontChannelLogoutUri = "https://localhost:44346/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44346/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "secretApi.read"
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }
    }
}
