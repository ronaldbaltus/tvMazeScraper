using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace TvMazeScraper.App.Services.Implementations
{
    /// <summary>
    /// The background service to scrape tvmaze.
    /// </summary>
    public class BackgroundScraperService : IBackgroundScraperService
    {
        private readonly ILogger<BackgroundScraperService> _logger;
        private readonly IServiceProvider _services;
        private readonly ApiClient.IApiClient _apiClient;
        private int _pageNumber = 1;
        private AsyncRetryPolicy _retryPolicy;
        private Task _task;
        private CancellationTokenSource _taskCancellation;

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundScraperService"/> class.
        /// </summary>
        /// <param name="logger">The logger scoped to this service.</param>
        /// <param name="services">Services provider.</param>
        /// <param name="apiClient">The client to access the api.</param>
        public BackgroundScraperService(ILogger<BackgroundScraperService> logger, IServiceProvider services, ApiClient.IApiClient apiClient)
        {
            _logger = logger;
            _services = services;
            _apiClient = apiClient;
            _retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(10, (i) =>
                {
                    if (i >= 10)
                    {
                        return TimeSpan.FromSeconds(120);
                    }

                    return TimeSpan.FromSeconds(i * i);
                });
        }

        /// <summary>
        /// Start the Backround service.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _taskCancellation = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _task = ExecuteAsync(_taskCancellation.Token);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Start the Backround service.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (await ScrapePage(_pageNumber) && !cancellationToken.IsCancellationRequested)
            {
                _pageNumber++;

                await Task.Delay(1000);
            }

            // We were stopped due to the end of the data. Reset page.
            _pageNumber = 0;
        }

        /// <summary>
        /// Stops the Backround service.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Awaitable task.</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (_task == null)
            {
                return Task.CompletedTask;
            }

            _taskCancellation.Cancel();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Scrapes the page of tvshows.
        /// </summary>
        /// <param name="page">Pagenumber.</param>
        /// <returns>Returns whether the page contained data (should we stop?).</returns>
        protected async Task<bool> ScrapePage(int page)
        {
            var shows = await _retryPolicy.ExecuteAsync(async () => await _apiClient.GetShows(page));

            foreach (var show in shows)
            {
                var cast = await _retryPolicy.ExecuteAsync(async () => await _apiClient.GetCast(show.Id));

                await AddTvShow(show, cast);
            }

            return shows.Any();
        }

        /// <summary>
        /// Adds the client data to the repository.
        /// </summary>
        /// <param name="show">The show data.</param>
        /// <param name="cast">The cast data.</param>
        /// <returns>Task.</returns>
        protected async Task AddTvShow(ApiClient.Models.Show show, IEnumerable<ApiClient.Models.CastEntry> cast)
        {
            using var scope = _services.CreateScope();

            var repository = scope.ServiceProvider.GetService<Db.Repositories.ITvMazeScraperRepository>();

            await repository.AddTvShow(new Db.Entities.TvShow()
            {
                TvMazeId = show.Id,
                Name = show.Name,
                Cast = cast.Select(c => new Db.Entities.Actor()
                {
                    TvMazeId = c.Person.Id,
                    Name = c.Person.Name,
                    Birthdate = c.Person.Birthday,
                }).ToList(),
            });
        }
    }
}
