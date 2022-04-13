using Microsoft.AspNetCore.Builder;

namespace CodeChallenge.WebApi.Infrastucture.Middlewares
{
    public static class MiddlewareRegistration
    {
        public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
        {
            // ---- register custom middlewares ----
            builder.UseMiddleware<LoggingMiddleware>();
            builder.UseMiddleware<ErrorMiddleware>();

            return builder;
        }
    }
}
