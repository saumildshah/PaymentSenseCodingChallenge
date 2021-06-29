using Microsoft.Extensions.DependencyInjection;
using Moq;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using Paymentsense.Coding.Challenge.Caching;
using Paymentsense.Coding.Challenge.HttpClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Tests.Builders
{
    public class CountryServiceBuilder
    {
        private readonly Mock<ICountryRestClient> _restClientMock;
        private readonly ICacheService _cacheService;


        public Mock<ICountryRestClient> RestClientMock
        {
            get
            {
                return _restClientMock;
            }
        }

        public CountryServiceBuilder(ICacheService cacheService)
        {
            _restClientMock = new Mock<ICountryRestClient>();
            _cacheService = cacheService;
        }

        public CountryService Build()
        {
            var countries = new List<Country>();
            countries.Add(new Country
            {
                Name = "aa",
                Borders = new List<string> { "aa", "bb" },
                Flag = "aa",
                Capital = "aa"
            });
            countries.Add(new Country
            {
                Name = "bb",
                Borders = new List<string> { "cc", "bb" },
                Flag = "bb",
                Capital = "bb"
            });

            var json = GetCountriesJson(countries);
            HttpContent content = new StringContent(json);
            _restClientMock.Setup(m => m.GetAsync(It.IsAny<string>(), null))
                .Returns(Task.FromResult(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = content }));

            return new CountryService(_restClientMock.Object, _cacheService);
        }


        private string GetCountriesJson(List<Country> obj)
        {
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Serialize<List<Country>>(obj);
        }


    }
}
