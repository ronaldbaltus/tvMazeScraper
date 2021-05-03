using Newtonsoft.Json;

namespace TvMazeScraper.Models
{
    /// <summary>
    /// Representing an identity model.
    /// </summary>
    public class AbstractEntity : AbstractModel
    {
        /// <summary>
        /// Gets or sets the id of the entity.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
