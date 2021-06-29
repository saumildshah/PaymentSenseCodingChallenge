using Microsoft.Extensions.Options;
using Paymentsense.Coding.Challenge.Api.Config;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.HttpClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Paymentsense.Coding.Challenge.Caching;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRestClient _restClient;
        private readonly ICacheService _cacheService;

        public CountryService(ICountryRestClient restClient, ICacheService cacheService)
        {
            _restClient = restClient;
            _cacheService = cacheService;
        }
        public async Task<Result<List<Country>>> GetAsync()
        {
            var responseWrapper = new Result<List<Country>>();
            var cacheItemKey = CacheService.GetCountries;

            var response = await (await Task.Factory.StartNew(() =>
                _cacheService.Get(cacheItemKey,
                () => _restClient.GetAsync(CountryRestClient.GetCountries).ConfigureAwait(false).GetAwaiter().GetResult(),300)));

            //= await _restClient.GetAsync(CountryRestClient.GetCountries);
            var json = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                responseWrapper.Response = GetCountriesFromJson(json);
                return responseWrapper;
            }

            //log error here and take correct action
            //throw new Exception(json);

            responseWrapper.Error = new ErrorResponse
            {
                Status = response.StatusCode,
                Message = json,
            };
            return responseWrapper;
        }

        private List<Country> GetCountriesFromJson(string json)
        {
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<List<Country>>(json, options);
        }
    }
}
