using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.IdentityConfiguration
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "secretApi",
                    DisplayName = "Secret Api",
                    Description = "access Secret Api",
                    Scopes = new List<string> { "secretApi.read", "secretApi.write"},
                    ApiSecrets = new List<Secret> {new Secret("topsecret".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }
    }
}
