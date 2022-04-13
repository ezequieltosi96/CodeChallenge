using CodeChallenge.Application.Exceptions;
using CodeChallenge.Application.Interfaces.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CodeChallenge.WebApi.Infrastucture.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingTool _loggingTool;

        public ErrorMiddleware(RequestDelegate next, ILoggingTool loggingTool)
        {
            _next = next;
            _loggingTool = loggingTool;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            string errorMessage = string.Empty;

            switch (exception)
            {
                case NotFoundException nf:
                    httpStatusCode = HttpStatusCode.NotFound;
                    errorMessage = nf.Message;
                    break;

                case Exception e:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    errorMessage = e.InnerException == null ? e.Message : $"{e.Message} -> {e.InnerException.Message}";
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            var result = JsonConvert.SerializeObject(new { error = errorMessage, statusCode = httpStatusCode });

            _loggingTool.LogError(result);

            return context.Response.WriteAsync(result);
        }
    }
}
