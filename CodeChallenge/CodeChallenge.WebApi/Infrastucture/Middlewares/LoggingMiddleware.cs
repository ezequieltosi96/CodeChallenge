using CodeChallenge.Application.Interfaces.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CodeChallenge.WebApi.Infrastucture.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingTool _loggingTool;

        public LoggingMiddleware(RequestDelegate next, ILoggingTool loggingTool)
        {
            _next = next;
            _loggingTool = loggingTool;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                await _next(context);
            }
            finally
            {
                sw.Stop();

                _loggingTool.LogRequest(context.Request.Method, context.Request.Path.Value, context.Response.StatusCode.ToString(), sw.ElapsedMilliseconds.ToString());
            }
        }
    }
}
