namespace Poc.TaskHub.Eai.Infrstructure.Abstractions
{
    /// <summary>
    /// Defines an adapter interface for executing queries and returning responses.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query to execute.</typeparam>
    /// <typeparam name="TResponse">The type of the response returned by the adapter.</typeparam>
    public interface IAdapter<TQuery, TResponse>
    {
        /// <summary>
        /// Executes the specified query and returns the response.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <returns>The response returned by the adapter.</returns>
        TResponse Execute(TQuery query);
    }
}