using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace TvMazeScraper.ApiClient.Implementations
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves the shows from the TvMaze
        /// </summary>
        /// <param name="pageNumber">The page to retrieve.</param>
        /// <returns>List of shows</returns>
        public Task<IEnumerable<Models.Show>> GetShows(int pageNumber)
        {
            return GetAsync<IEnumerable<Models.Show>>($"/show?page={pageNumber}");
        }

        /// <summary>
        /// Retrieves the shows from the TvMaze
        /// </summary>
        /// <param name="showId">The id of the show.</param>
        /// <returns>List of shows</returns>
        public Task<IEnumerable<Models.CastEntry>> GetCast(int showId)
        {
            return GetAsync<IEnumerable<Models.CastEntry>>($"/shows/{showId}/cast");
        }

        /// <summary>
        /// Helper to do the api call towards tvmaze.
        /// </summary>
        /// <typeparam name="T">Expected return payload.</typeparam>
        /// <param name="uri">postfix url for the api.</param>
        /// <returns>T</returns>
        protected async Task<T> GetAsync<T>(string uri)
        {
            var res = await _httpClient.GetAsync(uri);

            res.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<T>(await res.Content.ReadAsStringAsync());
        }
    }
}
