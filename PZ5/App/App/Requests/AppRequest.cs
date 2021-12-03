using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace App.Requests
{
    public class AppRequest
    {
        public double A { get; set; } = 0.0;
        public double B { get; set; } = 0.0;
        public double H { get; set; } = 0.0;

        public AppRequest(HttpRequest request)
        {
            var form = request.Form.ToList();
            {
                foreach (var param in form)
                {
                    switch (param.Key.ToLower())
                    {
                        case "a":
                            this.A = Convert.ToDouble(param.Value.ToArray()[0].ToString());
                            break;
                        case "b":
                            this.B = Convert.ToDouble(param.Value.ToArray()[0].ToString());
                            break;
                        case "h":
                            this.H = Convert.ToDouble(param.Value.ToArray()[0].ToString());
                            break;
                        default:
                            break;
                    }
                }
                
            }
        }
    }
}
