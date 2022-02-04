using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGames.Domain;

namespace VideoGames.Application.Interfaces
{
    public interface IGameGenre
    {
        Task<List<GameGenre>> GetAllAsync();
        Task<GameGenre> GetByIdAsync(Guid Id);
        Task<GameGenre> GetVideoGamesByGenreIdAsync(Guid id);
        Task Insert(GameGenre gameGenre);
        void Update(GameGenre gameGenre);
        void Delete(GameGenre gameGenre);
    }
}
