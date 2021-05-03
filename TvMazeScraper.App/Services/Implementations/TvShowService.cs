using System.Linq;
using System.Threading.Tasks;
using TvMazeScraper.Models;
using TvMazeScraper.App.Extensions;

namespace TvMazeScraper.App.Services.Implementations
{
    /// <summary>
    /// Implemenation of the TvShowService interface.
    /// Gives access to the TvShows.
    /// </summary>
    public class TvShowService : ITvShowService
    {
        private readonly Db.Repositories.ITvMazeScraperRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TvShowService"/> class.
        /// </summary>
        /// <param name="repository">The repository containing the data.</param>
        public TvShowService(Db.Repositories.ITvMazeScraperRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get the tvshows in a paginated list.
        /// </summary>
        /// <param name="pagination">Options to select the pagination.</param>
        /// <returns>Paginated list of tv shows.</returns>
        public PaginatedCollection<TvShow> GetTvShows(Options.PaginationOptions pagination)
        {
            var tvShows = new PaginatedCollection<TvShow>()
            {
                Items = _repository.TvShows
                    .OrderBy(t => t.Name)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .Select(t => t.ToModel())
                    .ToList(),
            };

            tvShows.Items.ForEach(t => t.Cast = t.Cast.OrderByDescending(a => a.BirthDate));

            tvShows.PagingInfo = new PaginatedCollectionInfo()
            {
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                ItemsOnpage = tvShows.Items.Count,
            };

            return tvShows;
        }
    }
}
