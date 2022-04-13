using CodeChallenge.Application.Interfaces.ElasticSearch;
using CodeChallenge.Application.Interfaces.Logging;
using CodeChallenge.Application.Interfaces.Mapping;
using CodeChallenge.Tools.Automapper;
using CodeChallenge.Tools.ElasticSearch;
using CodeChallenge.Tools.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CodeChallenge.Tools
{
    public static class ToolsServiceRegistration
    {
        public static IServiceCollection RegisterToolsServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IMapping, Mapping>();
            services.AddSingleton<ILoggingTool, LoggingTool>();
            services.AddSingleton<IElasticClient, ElasticClient>();

            return services;
        }
    }
}
