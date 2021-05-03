using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TvMazeScraper.Models
{
    /// <summary>
    /// Model representing a TvShow.
    /// </summary>
    public class TvShow : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the name of the Tv Show.
        /// </summary>
        [Required(ErrorMessage = "Missing TvShow's name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the cast of the TV Show.
        /// </summary>
        [Required(ErrorMessage = "Missing cast")]
        [JsonProperty("cast")]
        public IEnumerable<Actor> Cast { get; set; }
    }
}
