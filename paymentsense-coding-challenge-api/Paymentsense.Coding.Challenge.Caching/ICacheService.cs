using System;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Caching
{
    public interface ICacheService
    {
        Task<T> Get<T>(object key, Func<T> callback, int cacheTimeInSeconds);
    }
}
