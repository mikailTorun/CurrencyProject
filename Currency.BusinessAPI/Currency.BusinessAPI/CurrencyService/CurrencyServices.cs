

using Currency.BusinessAPI.Serializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Currency.BusinessAPI.CurrencyService
{
    public class CurrencyServices
    {
        private readonly string urlPatter = "http://localhost:7878/api/currency/getlist";

        public object getCurrencies(string code)
        {
            var client = new RestClient(urlPatter)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            request.AddHeader("code", code);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject(response.Content);
        }
    }
}
