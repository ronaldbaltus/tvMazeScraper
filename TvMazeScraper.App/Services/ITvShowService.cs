using System.Threading.Tasks;
using TvMazeScraper.Models;

namespace TvMazeScraper.App.Services
{
    /// <summary>
    /// Interface for the TvShowService.
    /// </summary>
    public interface ITvShowService
    {
        /// <summary>
        /// Get the tv shows and apply pagination.
        /// </summary>
        /// <param name="paginationOptions">Options to select the pagination.</param>
        /// <returns>Paginated list of TV Shows.</returns>
        PaginatedCollection<TvShow> GetTvShows(Options.PaginationOptions paginationOptions);
    }
}
