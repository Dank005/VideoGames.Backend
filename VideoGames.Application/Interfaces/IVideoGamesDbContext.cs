using Microsoft.EntityFrameworkCore;
using VideoGames.Domain;

namespace VideoGames.Application.Interfaces
{
    public interface IVideoGamesDbContext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
    }
}
