using System.Collections.Generic;
using System.Threading.Tasks;

namespace TvMazeScraper.ApiClient
{
    public interface IApiClient
    {
        /// <summary>
        /// Retrieves the shows from the TvMaze
        /// </summary>
        /// <param name="pageNumber">The page to retrieve.</param>
        /// <returns>List of shows</returns>
        Task<IEnumerable<Models.Show>> GetShows(int pageNumber);

        /// <summary>
        /// Retrieves the shows from the TvMaze
        /// </summary>
        /// <param name="showId">The id of the show.</param>
        /// <returns>List of shows</returns>
        Task<IEnumerable<Models.CastEntry>> GetCast(int showId);
    }
}
