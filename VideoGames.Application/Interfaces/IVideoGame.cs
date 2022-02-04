using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGames.Domain;

namespace VideoGames.Application.Interfaces
{
    public interface IVideoGame
    {
        Task<List<VideoGame>> GetAllAsync();
        Task<VideoGame> GetByIdAsync(Guid Id);
        Task<VideoGame> GetGenresByVideoGameIdAsync(Guid id);
        Task Insert(VideoGame videoGame);
        void Update(VideoGame videoGame);
        void Delete(VideoGame videoGame);
    }
}
