using Microsoft.Extensions.DependencyInjection;
using Moq;
using Paymentsense.Coding.Challenge.Api.Tests.Builders;
using Paymentsense.Coding.Challenge.Caching;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services
{
    public class CountryServiceTests
    {
        private ServiceProvider ServiceProvider { get; set; }
        public CountryServiceTests()
        {
            ServiceProvider = RegisterServices();
        }

        private ServiceProvider RegisterServices()
        {
            return new ServiceCollection()
                .AddMemoryCache()
                .AddSingleton<ICacheService, CacheService>()
                .BuildServiceProvider();
        }

        [Fact]
        public void Get_ReturnsExpectedCountries()
        {
            var cacheService = ServiceProvider.GetService<ICacheService>();
            var builder = new CountryServiceBuilder(cacheService);
            var service = builder.Build();

            var result = service.GetAsync().Result;

            Assert.Null(result.Error);
            Assert.True(result.Success);
            Assert.NotNull(result.Response);
            Assert.True(result.Response.Count > 0);

            builder.RestClientMock.Verify(b => b.GetAsync(It.IsAny<string>(), null), Times.Once);
        }
    }
}
