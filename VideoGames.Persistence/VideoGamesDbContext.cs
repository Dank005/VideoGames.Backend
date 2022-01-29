using Microsoft.EntityFrameworkCore;

using VideoGames.Application.Interfaces;
using VideoGames.Domain;
using VideoGames.Persistence.EntityTypeConfigurations;

namespace VideoGames.Persistence
{
    public class VideoGamesDbContext : DbContext, IVideoGamesDbContext
    {
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
       
        public VideoGamesDbContext(DbContextOptions<VideoGamesDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new VideoGameConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
