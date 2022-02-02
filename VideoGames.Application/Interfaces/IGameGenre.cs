using System;
using System.Collections.Generic;
using VideoGames.Domain;

namespace VideoGames.Application.Interfaces
{
    public interface IGameGenre
    {
        List<GameGenre> GetAll();
        GameGenre GetById(Guid Id);
        GameGenre GetVideoGamesByGenreId(Guid id);
        void Insert(GameGenre gameGenre);
        void Update(GameGenre gameGenre);
        void Delete(GameGenre gameGenre);
    }
}
