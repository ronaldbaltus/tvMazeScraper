using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TvMazeScraper.Db.Entities;

namespace TvMazeScraper.Db.Configurations
{
    /// <summary>
    /// Configuration class to configure the <see cref="TvMazeScraper.Models.Actor"/> entity.
    /// </summary>
    public class ActorEntityConfiguration : IEntityTypeConfiguration<Actor>
    {
        /// <summary>
        /// Configure the TvShow entity.
        /// </summary>
        /// <param name="builder">The entity builder.</param>
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.ToTable(nameof(Actor));

            builder
                .HasOne(a => a.TvShow)
                .WithMany(t => t.Cast)
                .HasForeignKey(a => a.TvShowId)
            ;
        }
    }
}
