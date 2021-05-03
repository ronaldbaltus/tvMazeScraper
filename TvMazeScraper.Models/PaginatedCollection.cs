using Newtonsoft.Json;

namespace TvMazeScraper.Models
{
    /// <summary>
    /// Represents a portion of the data with indication on how to get remaining data.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    public class PaginatedCollection<T> : Collection<T>
        where T : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the information about the current paginated view.
        /// </summary>
        [JsonProperty("pagingInfo")]
        public PaginatedCollectionInfo PagingInfo { get; set; }
    }
}
