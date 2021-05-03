using Newtonsoft.Json;

namespace TvMazeScraper.Models
{
    /// <summary>
    /// Represents information what portion of the data is show and how many there are remaining.
    /// </summary>
    public class PaginatedCollectionInfo
    {
        /// <summary>
        /// Gets or sets the total items in the Paginated collection.
        /// </summary>
        [JsonProperty("totalItems")]
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Gets or sets the number of items on page.
        /// </summary>
        [JsonProperty("itemsOnPage")]
        public int ItemsOnpage { get; set; }

        /// <summary>
        /// Gets a value indicating whether there is a page before this page.
        /// </summary>
        [JsonProperty("hasPreviousPage")]
        public bool HasPreviousPage { get => this.PageNumber > 1; }

        /// <summary>
        /// Gets a value indicating whether there is a page after this page.
        /// </summary>
        [JsonProperty("hasNextPage")]
        public bool HasNextPage { get => (this.PageNumber * this.PageSize) < this.TotalItems; }
    }
}
