using Moq;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Tests.Builders
{
    public class CountryControllerBuilder
    {
        private readonly Mock<ICountryService> _countryServiceMock;
        public Mock<ICountryService> CountryServiceMock
        {
            get
            {
                return _countryServiceMock;
            }
        }

        public CountryControllerBuilder()
        {
            _countryServiceMock = new Mock<ICountryService>();
        }

        public CountryController Build()
        {
            return new CountryController(_countryServiceMock.Object);
        }

        public CountryControllerBuilder WithGetSuccessResponseAsync()
        {
            var countries = new List<Country>();
            countries.Add(new Country
            {
                Name = "aa",
                Borders = new List<string>{ "aa", "bb" },
                Flag = "aa",
                Capital = "aa"
            });

            var result = new Result<List<Country>>
            {
                Error = null,
                Response = countries
            };

            _countryServiceMock.Setup(m => m.GetAsync()).Returns(Task.FromResult(result));
            return this;
        }


        public CountryControllerBuilder WithGetErrorResponseAsync()
        {
            var error = new ErrorResponse
            {
                Status = System.Net.HttpStatusCode.InternalServerError,
                Message = "Network error",
            };
            
            var result = new Result<List<Country>>
            {
                Error = error,
                Response = null
            };

            _countryServiceMock.Setup(m => m.GetAsync()).Returns(Task.FromResult(result));
            return this;
        }

    }
}
