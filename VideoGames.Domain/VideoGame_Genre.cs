using System;

namespace VideoGames.Domain
{
    public class VideoGame_Genre
    {
        public Guid VideoGameId { get; set; }
        public Guid GameGenreId { get; set; }
        public VideoGame VideoGame { get; set; }
        public GameGenre GameGenre { get; set; }
    }
}
