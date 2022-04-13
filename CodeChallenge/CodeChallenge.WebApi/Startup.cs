using CodeChallenge.Application;
using CodeChallenge.Application.Interfaces.Mediator.Command;
using CodeChallenge.Application.Interfaces.Mediator.Query;
using CodeChallenge.Persistence;
using CodeChallenge.Tools;
using CodeChallenge.WebApi.Infrastucture.Mediator;
using CodeChallenge.WebApi.Infrastucture.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeChallenge.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterApplicationServices();
            services.RegisterToolsServices();
            services.RegisterPersistanceServices();

            services.AddScoped<IQueryProcessor, QueryProcessor>();
            services.AddScoped<ICommandProcessor, CommandProcessor>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCustomMiddlewares();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
