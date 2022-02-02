using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;

namespace VideoGames.Persistence.Repositories
{
    public class GameGenreRepo : IGameGenre
    {
        private readonly VideoGamesDbContext _context;

        public GameGenreRepo(VideoGamesDbContext context)
        {
            _context = context;
        }

        public List<GameGenre> GetAll()
        {
            return _context.GameGenres.ToList();
        }

        public GameGenre GetById(Guid Id)
        {
            return _context.GameGenres.FirstOrDefault(x => x.Id == Id);
        }
        public GameGenre GetVideoGamesByGenreId(Guid id)
        {
            return _context.GameGenres.Include(x => x.VideoGame_Genres)
                .ThenInclude(y => y.VideoGame).SingleOrDefault(m => m.Id == id);
        }

        public void Insert(GameGenre gameGenre)
        {
            _context.GameGenres.Add(gameGenre);
        }

        public void Update(GameGenre gameGenre)
        {
            _context.GameGenres.Update(gameGenre);
        }
        public void Delete(GameGenre gameGenre)
        {
            _context.GameGenres.Remove(gameGenre);
        }
    }
}
