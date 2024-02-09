namespace Poc.TaskHub.Business.Queries.Infrastructure
{
    /// <summary>
    /// Encapsulates a paginated response, including the data and associated metadata.
    /// </summary>
    /// <param name="Data"></param>
    /// <param name="MetaData"></param>
    /// <param name="Data">The data items for the current page.</param>
    /// <param name="MetaData">Metadata associated with the paginated response.</param>
    public record PaginatedDataView<T>(IEnumerable<T> Data, MetaDataDataView MetaData)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedDataView{T}"/> class with default values.
        /// </summary>
        public PaginatedDataView() : this(default, default)
        {
        }
    }
}