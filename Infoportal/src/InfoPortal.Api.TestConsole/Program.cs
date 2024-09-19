using InfoPortal.TestConsole;
using Microsoft.Extensions.DependencyInjection;

public class Program
{

    public static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        DependencyInjection.Configure(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var mainService = serviceProvider.GetService<Startup>();


        await mainService.StartAsync();

    }

}