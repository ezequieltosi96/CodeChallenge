using CodeChallenge.Application.Interfaces.Logging;
using Newtonsoft.Json;
using Serilog;

namespace CodeChallenge.Tools.Logging
{
    public class LoggingTool : ILoggingTool
    {
        public LoggingTool()
        {
            Refresh();
        }

        private void Refresh()
        {
            Log.CloseAndFlush();

            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public void LogCommandHandler(string handlerTypeName, object command)
        {
            var commandAsString = JsonConvert.SerializeObject(command);

            Log.Information($"Handler: {handlerTypeName} - Command: {commandAsString}");
        }

        public void LogError(string error)
        {
            Log.Error(error);
        }

        public void LogRequest(string method, string endpoint, string statusCode, string elapsedTime)
        {
            Log.Information($"Request finished in {elapsedTime}ms - Response Status Code: {statusCode} - Method: {method} - Endpoint: {endpoint}");
        }

        public void LogQueryHandler(string handlerTypeName, object query)
        {
            var queryAsString = JsonConvert.SerializeObject(query);

            Log.Information($"Handler: {handlerTypeName} - Query: {queryAsString}");
        }
    }
}
