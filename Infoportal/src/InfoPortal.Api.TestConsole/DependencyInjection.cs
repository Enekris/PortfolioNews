using InfoPortal.Api.Client.Configuration;
using InfoPortal.Logic.Configuration;
using InfoPortal.Persistence.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfoPortal.TestConsole
{
    public static class DependencyInjection
    {
        public static void Configure(this IServiceCollection serviceCollection)
        {
            var appPath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(appPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();


            serviceCollection.AddScoped<Startup>();

            serviceCollection.AddPersistence(configuration);

            serviceCollection.AddLogic();

            serviceCollection.AddClient(configuration);


        }
    }
}

