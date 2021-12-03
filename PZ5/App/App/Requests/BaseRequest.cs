using Microsoft.AspNetCore.Http;
using System.Linq;

namespace App.Requests
{
    public class BaseRequest
    {
        internal string PrefixTable;
        public BaseRequest(HttpRequest request)
        {
            foreach (var hdr in request.Headers.ToList())
            {
                switch (hdr.Key)
                {
                    case "prefix_table":
                        this.PrefixTable = hdr.Value.ToArray()[0].Trim();
                        break;
                }
            }
        }
    }
}
