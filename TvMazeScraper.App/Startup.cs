using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace TvMazeScraper.App
{
    /// <summary>
    /// Represents the startup of the App.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration for the App.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the app configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure database.
            services.AddDbContext<Db.TvMazeScraperContext>((options) =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("MsSql"));
            });

            services.AddHttpClient<ApiClient.IApiClient, ApiClient.Implementations.ApiClient>((client) =>
            {
                var url = this.Configuration.GetSection("TvMaze")["Url"];

                client.BaseAddress = new Uri(url);
            });

            // Load data services.
            services.AddTransient<Db.Repositories.ITvMazeScraperRepository, Db.Repositories.Implementations.TvMazeScraperRepository>();
            services.AddTransient<Services.ITvShowService, Services.Implementations.TvShowService>();

            // Load web services.
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TvMazeScraper", Version = "v1" });
            });

            // Start scraperr.
            services.AddHostedService<Services.Implementations.BackgroundScraperService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The app that is being setup.</param>
        /// <param name="env">The host environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TvMazeScraper v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
