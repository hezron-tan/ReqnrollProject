using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject
{
    public class APIRestSharp
    {
        /// <summary>
        /// URL Test
        /// </summary>
        private string apiTestUrl = @" https://automationexercise.com/api";

        /// <summary>
        /// Rest Client
        /// </summary>
        public RestClient Client { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        public APIRestSharp()
        {
            Client = new RestClient(new RestClientOptions()
            {
                BaseUrl = new Uri(apiTestUrl)
            });
        }
    }
}
