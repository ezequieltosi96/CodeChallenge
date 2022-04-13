using CodeChallenge.Application.Interfaces.Logging;
using CodeChallenge.Application.Interfaces.Mediator.Query;
using System;

namespace CodeChallenge.WebApi.Infrastucture.Mediator
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoggingTool _loggingTool;

        public QueryProcessor(IServiceProvider serviceProvider, ILoggingTool loggingTool)
        {
            _serviceProvider = serviceProvider;
            _loggingTool = loggingTool;
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            Type handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = _serviceProvider.GetService(handlerType);

            _loggingTool.LogQueryHandler(handler.GetType().Name, query);

            return handler.Handle((dynamic) query);
        }
    }
}
