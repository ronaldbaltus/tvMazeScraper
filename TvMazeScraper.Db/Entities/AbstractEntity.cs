namespace TvMazeScraper.Db.Entities
{
    /// <summary>
    /// Abstract entity containing the fields that all entities should have.
    /// </summary>
    public abstract class AbstractEntity
    {
        /// <summary>
        /// Gets or sets the Id of the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the id at tvMaze.
        /// </summary>
        public int TvMazeId { get; set; }
    }
}
