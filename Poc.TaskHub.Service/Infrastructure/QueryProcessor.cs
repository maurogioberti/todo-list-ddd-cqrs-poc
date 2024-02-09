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
            dynamic handler = _container.GetInstance(handlerType);
            return handler.Handle(query);
        }
    }
}