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
        [Route("get_square")]
        public async Task<IActionResult> GetSquare()
        {
            Requests.AppRequest request = new Requests.AppRequest(this.Request);

            double square = 0.5 * (request.A + request.B) * request.H;
            
            MyClassResponse res = new MyClassResponse();
            res.Success = "success";
            res.Result = square;
            res.Version = "1.0";
            return this.Json(res);
        }
    }
}
