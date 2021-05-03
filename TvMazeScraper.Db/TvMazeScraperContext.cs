using Microsoft.EntityFrameworkCore;
using TvMazeScraper.Db.Entities;

namespace TvMazeScraper.Db
{
    /// <summary>
    /// The DbContext for accessing TvMazeScraper data.
    /// </summary>
    public class TvMazeScraperContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TvMazeScraperContext"/> class.
        /// </summary>
        /// <param name="options">The options for the DbContext.</param>
        public TvMazeScraperContext(DbContextOptions<TvMazeScraperContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets access to the Tv Shows in the database.
        /// </summary>
        public DbSet<TvShow> TvShows { get; private set; }

        /// <summary>
        /// Gets access to the actors in the database.
        /// </summary>
        public DbSet<Actor> Actors { get; private set; }

        /// <summary>
        /// Apply our entity settings when models get created.
        /// </summary>
        /// <param name="modelBuilder">The model builder use to define the entities.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Configurations.ActorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TvShowEntityConfiguration());
        }
    }
}
