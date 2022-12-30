using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer4.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DemoController : ControllerBase
    {
        // value of test array testarray will return if access token is valid
        int[] testarray = new int[] { 1, 3, 5, 7, 9, 7, 7 };
        private static readonly int Result;
        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Demo> Get()
        {
            var R = Enumerable.Range(0, 2).Select(x => new Demo
            {
                Result = testarray[testarray.Length -2]
            }).ToArray();

            return R;
        }         
    }
}
