using System.Threading.Tasks;

namespace VideoGames.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IVideoGame VideoGame { get; }
        IGameGenre GameGenre { get; }

        Task SaveAsync();
    }
}
