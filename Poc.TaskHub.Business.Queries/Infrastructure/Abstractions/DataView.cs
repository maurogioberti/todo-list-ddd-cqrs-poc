namespace Poc.TaskHub.Business.Queries.Infrastructure.Abstractions
{
    /// <summary>
    /// Provides a generic structure for data views with an identifier.
    /// </summary>
    /// <typeparam name="T">The type of the identifier.</typeparam>
    public abstract class DataView<T>
    {
        /// <summary>
        /// Gets or sets the identifier of the data view.
        /// </summary>
        public required T Id { get; set; }
    }
}