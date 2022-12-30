using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer4.IdentityConfiguration
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser> 
            {
                new TestUser 
                {
                    SubjectId = "234567",
                    Username = "testuser",
                    Password = "password",
                    Claims = new List<Claim> 
                    {
                        new Claim(JwtClaimTypes.Email, "testuser@com"),
                        new Claim(JwtClaimTypes.Role, "administrator")
                        new Claim(JwtClaimTypes.WebSite, "https://ms.com"),
                    }
                }
            };
        }
    }
}
