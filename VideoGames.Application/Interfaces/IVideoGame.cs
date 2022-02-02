using System;
using System.Collections.Generic;
using VideoGames.Domain;

namespace VideoGames.Application.Interfaces
{
    public interface IVideoGame
    {
        List<VideoGame> GetAll();
        VideoGame GetById(Guid Id);
        VideoGame GetGenresByVideoGameId(Guid id);
        void Insert(VideoGame videoGame);
        void Update(VideoGame videoGame);
        void Delete(VideoGame videoGame);
    }
}
