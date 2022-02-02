namespace VideoGames.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IVideoGame VideoGame { get; }
        IGameGenre GameGenre { get; }

        void Save();
    }
}
