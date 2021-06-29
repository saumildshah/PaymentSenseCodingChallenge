using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Caching
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public const string GetCountries = "country-list";

        public CacheService(IMemoryCache memorycache)
        {
            _cache = memorycache;
        }
        public async Task<T> Get<T>(object key, Func<T> callback, int cacheTimeInSeconds)
        {
            return await _cache.GetOrCreateAsync(key, (entry) =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(cacheTimeInSeconds);

                return Task.FromResult(callback.Invoke());
            });
        }
    }
}
