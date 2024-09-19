using InfoPortal.Host.Configuration.Mapping;
using InfoPortal.Host.Extensions;
using InfoPortal.Host.Middleware;
using InfoPortal.Logic.Configuration;
using InfoPortal.Persistence.Configuration;

namespace InfoPortal.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
            services.AddSwagger();
            services.AddControllers();
            services.AddAutoMapper(typeof(ApiMappingProfile));
            services.AddEndpointsApiExplorer();

            services.AddLogic();
            services.AddPersistence(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.SwaggerConfiguration(Configuration);
        }
    }
}
