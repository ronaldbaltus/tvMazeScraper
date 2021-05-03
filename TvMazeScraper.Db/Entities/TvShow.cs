using System.Collections.Generic;

namespace TvMazeScraper.Db.Entities
{
    /// <summary>
    /// TvShow entity.
    /// </summary>
    public class TvShow : AbstractEntity
    {
        /// <summary>
        /// Gets or sets the name of the tv show.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the cast of the show.
        /// </summary>
        public ICollection<Actor> Cast { get; set; }
    }
}
