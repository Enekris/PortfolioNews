using InfoPortalWpf.ViewModels.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InfoPortalWpf.ViewModels.Services
{
    public static class DependensyInjection
    {
        public static IServiceCollection AddWpfServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<INewsService, NewsService>();
            serviceCollection.AddScoped<ITagsService, TagsService>();
            return serviceCollection;
        }
    }
}
