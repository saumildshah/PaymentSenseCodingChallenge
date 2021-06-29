using Microsoft.Extensions.DependencyInjection;
using Paymentsense.Coding.Challenge.Caching;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services
{
    public class CacheServiceTests
    {
        private ServiceProvider ServiceProvider { get; set; }
        string key = "Test";
        string key2 = "Test2";
        int counter = 0;
        public CacheServiceTests()
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
        public void ValueComesFromCacheSecondTimeOnwards()
        {
            var cacheService = ServiceProvider.GetService<ICacheService>();
            //Should call method and store value in cache
            cacheService.Get<string>(key,
                () => TestMethodShouldBeCalledOnlyOnce(), 300);

            //Should not call function and value must come from cache.
            cacheService.Get<string>(key,
                () => TestMethodShouldBeCalledOnlyOnce(), 300);

            //Should not call function and value must come from cache.
            cacheService.Get<string>(key,
                () => TestMethodShouldBeCalledOnlyOnce(), 300);

            Assert.Equal(1, counter);
        }

        [Fact]
        public void ShouldBeCalledTwiceIfUsingDifferentCacheKey()
        {
            var cacheService = ServiceProvider.GetService<ICacheService>();
            //Should call method and store value in cache
            cacheService.Get<string>(key,
                () => TestMethodShouldBeCalledOnlyOnce(), 300);

            //Should not call function and value must come from cache.
            cacheService.Get<string>(key2,
                () => TestMethodShouldBeCalledOnlyOnce(), 300);


            Assert.Equal(2, counter);
        }

        private string TestMethodShouldBeCalledOnlyOnce()
        {
            counter++;
            return "Test Method";
        }

    }
}
