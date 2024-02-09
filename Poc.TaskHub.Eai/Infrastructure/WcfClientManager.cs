using Poc.TaskHub.CrossCutting.Exceptions;
using Poc.TaskHub.Eai.Infrstructure.Abstractions;
using System.ServiceModel;

namespace Poc.TaskHub.Eai.Infrstructure
{
    /// <summary>
    /// Manages the creation and invocation of WCF service clients.
    /// </summary>
    /// <typeparam name="TClient">The type of the WCF service client.</typeparam>
    public class WcfClientManager<TClient> : IWcfClientManager<TClient> where TClient : class, ICommunicationObject, new()
    {
        //TODO: This class provides a demonstration of integrating WCF clients in this project, but it's not currently used.

        /// <summary>
        /// Invokes the specified service operation using the provided service client.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response from the service operation.</typeparam>
        /// <param name="invoker">The function representing the service operation to invoke.</param>
        /// <param name="client">The WCF service client to use for the invocation.</param>
        /// <param name="sessionID">The session ID associated with the invocation.</param>
        /// <returns>The response from the service operation.</returns>
        public TResponse InvokeService<TResponse>(Func<TClient, TResponse> invoker, TClient client = null, long sessionID = default(long))
        {
            Argument.ThrowIfNull(() => invoker);

            client ??= CreateClient(sessionID);

            TResponse response;

            try
            {
                response = invoker(client);

                client.Close();
            }
            catch (Exception)
            {
                client.Abort();

                throw;
            }

            return response;
        }

        /// <summary>
        /// Creates a new instance of the WCF service client.
        /// </summary>
        /// <param name="sessionID">The session ID associated with the client creation.</param>
        /// <returns>A new instance of the WCF service client.</returns>
        protected virtual TClient CreateClient(long sessionID)
        {
            return new TClient();
        }
    }
}