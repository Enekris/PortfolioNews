using InfoPortal.Application.Contracts.Database.Repositories;
using InfoPortal.Persistence.DbSettings;
using InfoPortal.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfoPortal.Persistence.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
             this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddRepositories();
            services.AddContext(configuration);

            return services;
        }

        private static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<ITagsRepository, TagsRepository>();

            return services;
        }

        private static IServiceCollection AddContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<InfoPortalDBContext>(builder =>
                    builder.UseMySql(
                       configuration.GetConnectionString("InfoPortalDB"),
                       new MySqlServerVersion(new Version(8, 0, 26))
                   ));

            return services;
        }
    }
}
