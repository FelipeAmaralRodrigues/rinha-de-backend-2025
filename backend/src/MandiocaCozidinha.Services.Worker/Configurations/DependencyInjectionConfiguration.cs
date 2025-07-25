using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MandiocaCozidinha.Services.Worker.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // loggers
            services.AddLogging(builder => builder.AddSerilog());
        }
    }
}