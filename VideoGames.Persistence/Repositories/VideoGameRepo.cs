using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;

namespace VideoGames.Persistence.Repositories
{
    public class VideoGameRepo : IVideoGame
    {
        private readonly VideoGamesDbContext _context;

        public VideoGameRepo(VideoGamesDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoGame>> GetAllAsync()
        {
            var result = await _context.VideoGames.ToListAsync();
            return result;
        }

        public async Task<VideoGame> GetByIdAsync(Guid Id)
        {
            var result = await _context.VideoGames.FirstOrDefaultAsync(x => x.Id == Id);
            return result;
        }

        public async Task<VideoGame> GetGenresByVideoGameIdAsync(Guid id)
        {
            var result = await _context.VideoGames.Include(x => x.VideoGame_Genres)
                .ThenInclude(y => y.GameGenre).SingleOrDefaultAsync(m => m.Id == id);
            return result;
        }

        public async Task Insert(VideoGame videoGame)
        {
            await _context.VideoGames.AddAsync(videoGame);
        }

        public void Update(VideoGame videoGame)
        {
            _context.VideoGames.Update(videoGame);
        }

        public void Delete(VideoGame videoGame)
        {
            _context.VideoGames.Remove(videoGame);
        }
    }
}
