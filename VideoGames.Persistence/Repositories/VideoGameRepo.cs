using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<VideoGame> GetAll()
        {
            return _context.VideoGames.ToList();
        }

        public VideoGame GetById(Guid Id)
        {
            return _context.VideoGames.FirstOrDefault(x => x.Id == Id);
        }

        public VideoGame GetGenresByVideoGameId(Guid id)
        {
            return _context.VideoGames.Include(x => x.VideoGame_Genres)
                .ThenInclude(y => y.GameGenre).SingleOrDefault(m => m.Id == id);
        }

        public void Insert(VideoGame videoGame)
        {
            _context.VideoGames.Add(videoGame);
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
