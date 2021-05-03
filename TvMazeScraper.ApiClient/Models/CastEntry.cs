namespace TvMazeScraper.ApiClient.Models
{
    public class CastEntry
    {
        /// <summary>
        /// Gets or sets the person on this cast entry.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("person")]
        public Person Person { get; set; }
    }
}
