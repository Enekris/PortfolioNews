using InfoPortal.Application;
using InfoPortal.Application.Contracts.Logic.Services.News;
using InfoPortal.Application.Contracts.Logic.Services.Tags;
using InfoPortal.Logic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InfoPortal.Logic.Configuration
{
    public static class DependencyInjection

    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<ITagsService, TagsService>();
            services.AddAutoMapper(typeof(AppMappingProfile));
            return services;
        }


    }
}
