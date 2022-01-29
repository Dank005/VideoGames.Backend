using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VideoGames.Domain;

namespace VideoGames.Application.Interfaces
{
    public interface IVideoGamesDbContext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }

        //not in many_To_many
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
