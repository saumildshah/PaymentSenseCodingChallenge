using Microsoft.Extensions.Options;

namespace Paymentsense.Coding.Challenge.HttpClient
{
    public class CountryRestClient : RestClient<RestClientSettings>, ICountryRestClient
    {
        public const string GetCountries = "all";
        public CountryRestClient(IOptions<RestClientSettings> options)
            : base(options)
        {
            
        }
    }
}
