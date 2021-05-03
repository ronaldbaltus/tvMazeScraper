using System;

namespace TvMazeScraper.Db.Entities
{
    /// <summary>
    /// The actor representation of the database.
    /// </summary>
    public class Actor : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the name of the actor.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthdate of the actor.
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Gets or sets the Tvshow where the actor is a part of.
        /// </summary>
        public TvShow TvShow { get; set; }

        /// <summary>
        /// Gets or sets the id of the TvShow.
        /// </summary>
        public int TvShowId { get; set; }
    }
}
