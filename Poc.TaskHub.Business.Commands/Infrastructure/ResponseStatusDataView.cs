using System.Net;

namespace Poc.TaskHub.Business.Commands.Infrastructure
{
    /// <summary>
    /// Encapsulates the status information of an API response.
    /// </summary>
    /// <param name="Code">The HTTP status code of the response.</param>
    /// <param name="Message">A message corresponding to the status code.</param>
    /// <param name="Details">Additional details about the response.</param>
    public record ResponseStatusDataView(int Code, string Message, string Details)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseStatusDataView"/> class with default values.
        /// </summary>
        public ResponseStatusDataView() : this((int)HttpStatusCode.OK, HttpStatusCode.OK.ToString(), string.Empty)
        {
        }
    }
}