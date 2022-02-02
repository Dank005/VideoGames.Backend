using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.Application.Interfaces;

namespace VideoGames.Persistence.Repositories
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly VideoGamesDbContext _context;
        private VideoGameRepo _videoGameRepo;
        private GameGenreRepo _gameGenreRepo;

        public UnitOfWorkRepo(VideoGamesDbContext context)
        {
            _context = context;
        }

        public IVideoGame VideoGame
        {
            get { return _videoGameRepo = _videoGameRepo ?? new VideoGameRepo(_context); }
        }

        public IGameGenre GameGenre
        {
            get { return _gameGenreRepo = _gameGenreRepo ?? new GameGenreRepo(_context); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
