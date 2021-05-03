using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TvMazeScraper.Models;

namespace TvMazeScraper.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TvShowsController : ControllerBase
    {
        private readonly ILogger<TvShowsController> _logger;

        public TvShowsController(ILogger<TvShowsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedCollection<TvShow>), 200)]
        public async Task<IActionResult> Get(
            [FromQuery] Options.PaginationOptions paginationOptions,
            [FromServices] Services.ITvShowService tvShowService
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(tvShowService.GetTvShows(paginationOptions));
        }
    }
}
