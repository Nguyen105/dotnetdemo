using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IdServer4.WebAPI.Client.Models;
using IdServer4.WebAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdServer4.WebAPI.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private IIdentityServer4Service _identityServer4Service = null;
        public DemoController(IIdentityServer4Service identityServer4Service)
        {
            _identityServer4Service = identityServer4Service;
        }

        [HttpGet]
        public async Task<IEnumerable<Demo>> Get()
        {
            var OAuth2Token = await _identityServer4Service.GetToken("secretApi.read");
            using (var client = new HttpClient())
            {
                client.SetBearerToken(OAuth2Token.AccessToken);
                var result = await client.GetAsync("https://localhost:44394/demo");
                if (result.IsSuccessStatusCode)
                {
                    var model = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Demo>>(model);
                }
                else
                {
                    throw new Exception("Some Error while fetching Data");
                }
            }
        }

    }
}