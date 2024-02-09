using System.ServiceModel;

namespace Poc.TaskHub.Eai.Infrstructure.Abstractions
{
    /// <summary>
    /// Defines a contract for managing WCF service clients.
    /// </summary>
    /// <typeparam name="TClient">The type of the WCF service client.</typeparam>
    public interface IWcfClientManager<TClient> where TClient : class, ICommunicationObject, new()
    {
        /// <summary>
        /// Invokes a service operation using the provided service client.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response from the service operation.</typeparam>
        /// <param name="invoker">The function representing the service operation to invoke.</param>
        /// <param name="client">The WCF service client to use for the invocation.</param>
        /// <param name="sessionID">The session ID associated with the invocation.</param>
        /// <returns>The response from the service operation.</returns>
        TResponse InvokeService<TResponse>(Func<TClient, TResponse> invoker, TClient client = null, long sessionID = default);
    }
}