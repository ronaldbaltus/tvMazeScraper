using System.Linq;

namespace TvMazeScraper.App.Extensions
{
    public static class TvShowExtensions
    {
        /// <summary>
        /// Convert to the Model.
        /// </summary>
        /// <param name="tvShow">The entity to convert.</param>
        /// <returns>The model instance.</returns>
        public static Models.TvShow ToModel(this Db.Entities.TvShow tvShow)
        {
            return new Models.TvShow()
            {
                Id = tvShow.Id,
                Name = tvShow.Name,
                Cast = tvShow.Cast?.Select(a => a.ToModel()),
            };
        }
    }
}
