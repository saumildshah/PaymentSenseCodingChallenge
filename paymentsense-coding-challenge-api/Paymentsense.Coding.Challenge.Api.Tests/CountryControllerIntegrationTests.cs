using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests
{
    public class CountryControllerIntegrationTests
    {
        private readonly System.Net.Http.HttpClient _client;
        public CountryControllerIntegrationTests()
        {
            var builder = new WebHostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
                })
                .UseStartup<Startup>();
            
            var testServer = new TestServer(builder);
            
            _client = testServer.CreateClient();
        }

        [Fact]
        public async Task GetCountries_OnInvoke_ReturnsCountries()
        {
            var response = await _client.GetAsync("/api/country");

            response.StatusCode.Should().Be(StatusCodes.Status200OK);

        }
    }
}
