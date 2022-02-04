using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<List<GameGenre>> GetAllAsync()
        {
            var result = await _context.GameGenres.ToListAsync();
            return result;
        }

        public async Task<GameGenre> GetByIdAsync(Guid Id)
        {
            var result = await _context.GameGenres.FirstOrDefaultAsync(x => x.Id == Id);
            return result;
        }

        public async Task<GameGenre> GetVideoGamesByGenreIdAsync(Guid id)
        {
            var result = await _context.GameGenres.Include(x => x.VideoGame_Genres)
                .ThenInclude(y => y.VideoGame).SingleOrDefaultAsync(z => z.Id == id);
            return result;
        }

        public async Task Insert(GameGenre gameGenre)
        {
            await _context.GameGenres.AddAsync(gameGenre);
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
