using System.Linq;
using System.Threading.Tasks;
using TvMazeScraper.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace TvMazeScraper.Db.Repositories.Implementations
{
    /// <summary>
    /// Gives access to the Database data.
    /// </summary>
    public class TvMazeScraperRepository : ITvMazeScraperRepository
    {
        private readonly TvMazeScraperContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TvMazeScraperRepository"/> class.
        /// </summary>
        /// <param name="context">The db context containing the Tv shows and actors.</param>
        public TvMazeScraperRepository(TvMazeScraperContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Gets access to the TvShows.
        /// </summary>
        public IQueryable<TvShow> TvShows
        {
            get => _dbContext.TvShows.Include(tvShow => tvShow.Cast).AsQueryable();
        }

        /// <summary>
        /// Gets access to the Actors.
        /// </summary>
        public IQueryable<Actor> Actors
        {
            get => _dbContext.Actors.AsQueryable();
        }

        /// <summary>
        /// Add a TvShow to the repository.
        /// </summary>
        /// <param name="tvShow">The tvshow data.</param>
        /// <returns>Task.</returns>
        public async Task AddTvShow(TvShow tvShow)
        {
            _dbContext.TvShows.Add(tvShow);

            using var transaction = _dbContext.Database.BeginTransaction();

            _dbContext.SaveChanges();

            await transaction.CommitAsync();
        }
    }
}
