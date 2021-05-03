using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TvMazeScraper.App.Options
{
    /// <summary>
    /// Options to retrieve data with pagination.
    /// </summary>
    public class PaginationOptions
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        [Range(1, 50)]
        [JsonProperty("pageSize")]
        public int PageSize { get; set; } = 10;
    }
}
