using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Giphy
{
    public class GiphyClient
    {
        private readonly string search;
        private readonly RestClient client;

        public GiphyClient()
        {
            this.client = new RestClient();

        }  

        public IRestResponse<Response> GetRandomGif(string search)
        {
            //var uri = string.Format();
            var request = new RestRequest("http://api.giphy.com/v1/gifs/random?api_key=dc6zaTOxFJmzC&tag=" + search, Method.GET);
            IRestResponse<Response> response = client.Execute<Response>(request);
            return response;
        }

    }
}
