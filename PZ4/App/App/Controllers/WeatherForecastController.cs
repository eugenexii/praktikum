using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    [Route("test")]
    [ApiController]
    public class WeatherForecastController : Controller
    {
        [HttpPost]
        [HttpGet]
        [Produces("applcation/json")]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            return this.Json(new { result = "Hello World!" });
        }

        [HttpPost]
        [HttpGet]
        [Produces("applcation/json")]
        [Route("hello_world")]
        public async Task<IActionResult> Test()
        {
            MyClassResponse res = new MyClassResponse();
            res.Success = "success";
            res.Result = "hello_world!";
            res.Version = "1.0";
            return this.Json(res);
        }
    }
}
