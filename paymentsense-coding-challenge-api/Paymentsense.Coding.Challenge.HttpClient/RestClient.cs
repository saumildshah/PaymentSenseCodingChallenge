using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.HttpClient
{
    public class RestClient<TRestClientSettings> : IRestClient
        where TRestClientSettings : class, IRestClientSettings, new()
    {

        protected readonly string serviceUrl;
        public RestClient(IOptions<TRestClientSettings> options)
        {
            serviceUrl = options.Value.ApiUrl;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, Action<HttpRequestMessage> configureHttpRequest = null)
        {
            string fullUrl = this.serviceUrl + url;
            var client = new System.Net.Http.HttpClient(new HttpClientHandler());
            
            var request = GetHttpRequest(HttpMethod.Get, fullUrl);
            var response = await client.SendAsync(request);
            return response;
        }


        private HttpRequestMessage GetHttpRequest(HttpMethod method, string url, HttpContent httpContent = null)
        {
            var request = new HttpRequestMessage()
            {
                Method = method,
                RequestUri = new Uri(url),
                Content = httpContent
            };

            return request;
        }

    }
}
