using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VideoGames.Domain;

namespace VideoGames.Persistence.EntityTypeConfigurations
{
    public class VideoGameConfiguration : IEntityTypeConfiguration<VideoGame_Genre>
    {
        public void Configure(EntityTypeBuilder<VideoGame_Genre> builder)
        {
            builder.HasKey(vg => new { vg.VideoGameId, vg.GenreId });
            builder.HasOne(vg => vg.VideoGame)
                .WithMany(vg => vg.VideoGame_Genres).HasForeignKey(g => g.VideoGameId);

            builder.HasOne(vg => vg.GameGenre).WithMany(vg => vg.VideoGame_Genres).HasForeignKey(g => g.GenreId);

        }
    }
}
