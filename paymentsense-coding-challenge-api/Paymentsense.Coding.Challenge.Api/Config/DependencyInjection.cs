using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paymentsense.Coding.Challenge.Api.Services;
using Paymentsense.Coding.Challenge.Caching;
using Paymentsense.Coding.Challenge.HttpClient;

namespace Paymentsense.Coding.Challenge.Api.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfigurationSection appSettingsSection)
        {
            
            services.AddScoped<ICountryService, CountryService>();

            var appSettings = new AppSettings();
            appSettingsSection.Bind(appSettings);

            services.Configure<RestClientSettings>(o => o.ApiUrl = appSettings.RestCountryUrl);
            
            services.AddSingleton<ICountryRestClient, CountryRestClient>();
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, CacheService>();
            return services;
        }
    }
}
