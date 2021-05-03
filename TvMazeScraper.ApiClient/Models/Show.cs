using System.Collections.Generic;
using Newtonsoft.Json;

namespace TvMazeScraper.ApiClient.Models
{
    public class Show
    {
        /// <summary>
        /// Gets or sets the id of the show.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the show.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the cast on the show.
        /// </summary>
        [JsonProperty("cast")]
        public IEnumerable<CastEntry> Cast { get; set; }
    }
}
