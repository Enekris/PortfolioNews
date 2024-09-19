using Microsoft.AspNetCore.Hosting;

namespace InfoPortal.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);

            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            startup.Configure(app, app.Environment);

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = loggerFactory.CreateLogger<Program>();
            app.Run(async (context) =>
            {
                logger.LogInformation($"Requested Path: {context.Request.Path}");
                context.Response.WriteAsync("Hello World!");
            });

            app.Run();
        }

    }
}

