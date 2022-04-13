namespace CodeChallenge.Application.Interfaces.Logging
{
    public interface ILoggingTool
    {
        void LogCommandHandler(string handlerTypeName, object command);

        void LogQueryHandler(string handlerTypeName, object query);

        void LogError(string error);

        void LogRequest(string method, string endpoint, string statusCode, string elapsedTime);
    }
}
