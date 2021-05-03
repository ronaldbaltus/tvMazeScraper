using System;
using Newtonsoft.Json;

namespace TvMazeScraper.ApiClient.Models
{
    public class Person
    {
        /// <summary>
        /// Gets or sets the id of the person.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthdate of the person.
        /// </summary>
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }
    }
}
