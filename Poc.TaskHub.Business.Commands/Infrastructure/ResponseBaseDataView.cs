using Newtonsoft.Json;

namespace Poc.TaskHub.Business.Commands.Infrastructure
{
    /// <summary>
    /// Provides a base structure for API responses, including status information.
    /// </summary>
    /// <param name="Status">The status information of the API responseand any additional details.</param>
    public record ResponseBaseDataView([property: JsonProperty(Order = 0)] ResponseStatusDataView Status)
    {
        public ResponseBaseDataView() : this(new ResponseStatusDataView())
        {
        }

        /// <summary>
        /// Returns the string representation of this object.
        /// </summary>
        /// <returns>A JSON string representing this object.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}