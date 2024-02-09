using Poc.TaskHub.Business.Queries.Infrastructure.Abstractions;

namespace Poc.TaskHub.Service.Infrastructure.Abstractions
{
    /// <summary>
    /// Defines the interface for processing queries.
    /// </summary>
    public interface IQueryProcessor
    {
        /// <summary>
        /// Processes the specified query and returns a result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="query">The query to process.</param>
        /// <returns>The result of processing the query.</returns>
        TResult Process<TResult>(IQuery<TResult> query);
    }
}