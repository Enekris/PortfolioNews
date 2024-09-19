using InfoPortal.Api.Client.ApIClient.Interfaces;
using InfoPortal.Api.Client.ApIClient;
using Microsoft.Extensions.DependencyInjection;
using InfoPortal.Api.Client.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace InfoPortal.Api.Client.Configuration
{
    public static class DependencyInjection

    {
        public static IServiceCollection AddClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IApiNewsClient, ApiNewsClient>();
            services.AddHttpClient<IApiTagClient, ApiTagClient>();

            var apiClientSettingsSection = configuration.GetSection($"{nameof(ApiClientSettings)}");
            var options = apiClientSettingsSection.Get<ApiClientSettings>();

            services.Configure<ApiClientSettings>(x =>
            {
                x.BaseAddress = options.BaseAddress;
                x.RequestTimeOut = options.RequestTimeOut;
                x.Token = options.Token;
            });
           
            return services;
        }


    }
}
