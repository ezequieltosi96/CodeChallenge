using CodeChallenge.Application.Interfaces.Logging;
using CodeChallenge.Application.Interfaces.Mediator.Command;
using System;

namespace CodeChallenge.WebApi.Infrastucture.Mediator
{
    public sealed class CommandProcessor : ICommandProcessor
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoggingTool _loggingTool;

        public CommandProcessor(IServiceProvider serviceProvider, ILoggingTool loggingTool)
        {
            _serviceProvider = serviceProvider;
            _loggingTool = loggingTool;
        }

        public TResult Process<TResult>(ICommand<TResult> command)
        {
            Type handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = _serviceProvider.GetService(handlerType);

            _loggingTool.LogCommandHandler(handler.GetType().Name, command);

            return handler.Handle((dynamic)command);
        }
    }
}
