using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using App.Requests;
using App.Services;
using App.Structures;

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
            AppRequest request = new AppRequest(this.Request);

            double square = 0.5 * (request.A + request.B) * request.H;
            
            MyClassResponse res = new MyClassResponse();
            res.Success = "success";
            res.Result = square;
            res.Version = "1.0";
            return this.Json(res);
        }

        [HttpPost]
        [HttpGet]
        [Produces("applcation/json")]
        [Route("create_calc")]
        public async Task<IActionResult> CreateCalc()

        {
            AppRequest request = new AppRequest(this.Request);

            string path = Path.Combine(Params.DataSrc, "json_settings.txt");
            List<Results> content = new List<Results>();
            string str_content = System.IO.File.ReadAllText(path);
            if (!string.IsNullOrEmpty(str_content))
            {
                content = JsonConvert.DeserializeObject<List<Results>>(str_content);
            }
            Results elem = new Results();
            elem.uuid = Guid.NewGuid().ToString();
            elem.result = 0.5 * (request.A + request.B) * request.H;
            content.Add(elem);

            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(content));

            return this.Json(elem);
        }

        [HttpPost]
        [HttpGet]
        [Produces("applcation/json")]
        [Route("get_one_calc")]
        public async Task<IActionResult> GetOneCalc()

        {
            AppRequest request = new AppRequest(this.Request);

            string path = Path.Combine(Params.DataSrc, "json_settings.txt");
            Results obj = null;
            string str_content = System.IO.File.ReadAllText(path);
            if (!string.IsNullOrEmpty(str_content))
            {
                List<Results> content = JsonConvert.DeserializeObject<List<Results>>(str_content);
                foreach (var c in content)
                {
                    if (c.uuid == request.Guid)
                    {
                        obj = c;
                    }
                }
            }
            
            return this.Json(obj);
        }

        [HttpPost]
        [HttpGet]
        [Produces("applcation/json")]
        [Route("update_one_calc")]
        public async Task<IActionResult> UpdateOneCalc()

        {
            AppRequest request = new AppRequest(this.Request);
            bool update = false;

            List<Results> content = new List<Results>();
            string path = Path.Combine(Params.DataSrc, "json_settings.txt");
            string str_content = System.IO.File.ReadAllText(path);
            if (!string.IsNullOrEmpty(str_content))
            {
                content = JsonConvert.DeserializeObject<List<Results>>(str_content);
                foreach (var b in content)
                {
                    if (b.uuid == request.Guid)
                    {
                        b.result = 0.5 * (request.A + request.B) * request.H;
                        update = true;
                    }
                }
            }
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(content));

            return this.Json(new
            {
                result = update
            });
        }

        [HttpPost]
        [HttpGet]
        [Produces("applcation/json")]
        [Route("delete_one_calc")]
        public async Task<IActionResult> DeleteOneCalc()

        {
            AppRequest request = new AppRequest(this.Request);
            bool del = false;

            List<Results> content = new List<Results>();
            List<Results> final = new List<Results>();
            string path = Path.Combine(Params.DataSrc, "json_settings.txt");
            string str_content = System.IO.File.ReadAllText(path);

            if (!string.IsNullOrEmpty(str_content))
            {
                content = JsonConvert.DeserializeObject<List<Results>>(str_content);
                foreach (var b in content)
                {
                    if (b.uuid != request.Guid)
                    {
                        final.Add(b);
                        del = true;
                    }
                }
            }
            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(final));

            return this.Json(new
            {
                result = del
            });
        }
    }

}
