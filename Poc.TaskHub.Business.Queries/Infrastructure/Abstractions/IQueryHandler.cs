namespace Poc.TaskHub.Business.Queries.Infrastructure.Abstractions
{
    /// <summary>
    /// Defines a handler for processing a query and producing a result.
    /// </summary>
    public interface IQueryHandler<TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Handles the specified query and returns the result.
        /// </summary>
        /// <param name="query">The query to handle.</param>
        /// <returns>The result produced by handling the query.</returns>
        TResult Handle(TQuery query);
    }
}