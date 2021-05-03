using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TvMazeScraper.Models
{
    /// <summary>
    /// Model representing an actor.
    /// </summary>
    public class Actor : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the name of the actor.
        /// </summary>
        [Required(ErrorMessage = "Missing actors name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthdate of the actor.
        /// </summary>
        [Required(ErrorMessage = "Missing actors birthdate")]
        [JsonProperty("birthDate")]
        public DateTime? BirthDate { get; set; }
    }
}
