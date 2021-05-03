using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TvMazeScraper.Db.Entities;

namespace TvMazeScraper.Db.Configurations
{
    /// <summary>
    /// Configuration class to configure the <see cref="TvMazeScraper.Models.TvShow"/> entity.
    /// </summary>
    public class TvShowEntityConfiguration : IEntityTypeConfiguration<TvShow>
    {
        /// <summary>
        /// Configure the TvShow entity.
        /// </summary>
        /// <param name="builder">The entity builder.</param>
        public void Configure(EntityTypeBuilder<TvShow> builder)
        {
            builder.ToTable(nameof(TvShow));

            builder
                .HasMany(t => t.Cast)
                .WithOne(a => a.TvShow)
                .HasForeignKey(a => a.TvShowId)
                .IsRequired()
            ;
        }
    }
}
