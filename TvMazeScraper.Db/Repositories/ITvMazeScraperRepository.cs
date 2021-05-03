using System.Linq;
using System.Threading.Tasks;
using TvMazeScraper.Db.Entities;

namespace TvMazeScraper.Db.Repositories
{
    /// <summary>
    /// Interface representing the Tv MazeScraper repository.
    /// </summary>
    public interface ITvMazeScraperRepository
    {
        /// <summary>
        /// Gets access to the TvShows in the repository.
        /// </summary>
        public IQueryable<TvShow> TvShows { get; }

        /// <summary>
        /// Add a TvShow to the repository.
        /// </summary>
        /// <param name="tvShow">The tvshow data.</param>
        /// <returns>Task.</returns>
        public Task AddTvShow(TvShow tvShow);
    }
}
