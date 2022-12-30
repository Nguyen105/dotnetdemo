using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.IdentityConfiguration
{
    public class Scopes
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("secretApi.read", "Read Access to Secret API"),
                new ApiScope("secretApi.write", "Write Access to Secret API"),
            };
        }
    }
}
