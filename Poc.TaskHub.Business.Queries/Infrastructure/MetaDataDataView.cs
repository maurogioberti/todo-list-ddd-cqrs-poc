namespace Poc.TaskHub.Business.Queries.Infrastructure
{
    /// <summary>
    /// Provides metadata for paginated responses, including details about the pagination state and navigation links.
    /// </summary>
    /// <param name="PageNumber">The current page number in the paginated response.</param>
    /// <param name="PageSize">The number of items per page in the paginated response.</param>
    /// <param name="TotalPages">The total number of pages available in the paginated response.</param>
    /// <param name="TotalRecords">The total number of records available across all pages in the paginated response.</param>
    /// <param name="NextPageLink">A URL to the next page of results, if available; otherwise, an empty string.</param>
    /// <param name="PrevPageLink">A URL to the previous page of results, if available; otherwise, an empty string.</param>
    public record MetaDataDataView(int PageNumber, int PageSize, int TotalPages, int TotalRecords, string NextPageLink, string PrevPageLink)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataDataView"/> class with default values.
        /// </summary>
        public MetaDataDataView() : this(default, default, default, default, string.Empty, string.Empty)
        {
        }
    };
}