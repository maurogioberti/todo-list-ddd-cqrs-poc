using Lamar;
using Poc.TaskHub.Business.Queries.Infrastructure.Abstractions;
using Poc.TaskHub.CrossCutting.Exceptions;
using Poc.TaskHub.Service.Infrastructure.Abstractions;

namespace Poc.TaskHub.Api.Service.Infrastructure
{
    /// <summary>
    /// Processes queries by finding the appropriate query handler using dependency injection.
    /// </summary>
    public sealed class QueryProcessor : IQueryProcessor
    {
        /// <summary>
        /// The IoC container used for resolving query handlers.
        /// </summary>
        private readonly IContainer _container;

        private const string HandlerNotFoundErrorMessage = "No query handler registered for type {0}";
        private const string HandleMethodNotFoundErrorMessage = "Handle method not found on the query handler";
        private const string HandleMethodName = "Handle";

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryProcessor"/> class.
        /// </summary>
        /// <param name="container">The IoC container for resolving dependencies.</param>
        public QueryProcessor(IContainer container)
        {
            Argument.ThrowIfNull(() => container);
            _container = container;
        }

        /// <summary>
        /// Processes the specified query by finding and invoking the appropriate query handler.
        /// </summary>
        /// <typeparam name="TResult">The type of result expected from processing the query.</typeparam>
        /// <param name="query">The query to process.</param>
        /// <returns>The result produced by the query handler.</returns>
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            Argument.ThrowIfNull(() => query);

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = _container.GetInstance(handlerType);

            if (handler == null)
                throw new InvalidOperationException(string.Format(HandlerNotFoundErrorMessage, query.GetType().Name));

            var handleMethod = handlerType.GetMethod(HandleMethodName);
            if (handleMethod == null)
                throw new InvalidOperationException(HandleMethodNotFoundErrorMessage);

            var result = handleMethod.Invoke(handler, new object[] { query });
            return (TResult)result;
        }
    }
}