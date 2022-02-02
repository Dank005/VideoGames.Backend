using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGames.Domain;

namespace VideoGames.Persistence.EntityTypeConfigurations
{
    public class VideoGameConfiguration : IEntityTypeConfiguration<VideoGame_Genre>
    {
        public void Configure(EntityTypeBuilder<VideoGame_Genre> builder)
        {
            builder.HasKey(vgg => new { vgg.VideoGameId, vgg.GameGenreId });
            builder.HasOne(vgg => vgg.VideoGame)
                .WithMany(vgg => vgg.VideoGame_Genres).HasForeignKey(vg => vg.VideoGameId);
            builder.HasOne(vgg => vgg.GameGenre)
                .WithMany(vgg => vgg.VideoGame_Genres).HasForeignKey(vg => vg.GameGenreId);
        }
    }
}
