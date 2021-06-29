using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.HttpClient
{
    public interface IRestClient
    {
        Task<HttpResponseMessage> GetAsync(string url, Action<HttpRequestMessage> configureHttpRequest = null);
    }
}
