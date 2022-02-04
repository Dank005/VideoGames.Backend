using System;
using System.Collections.Generic;

namespace VideoGames.Domain
{
    public class GameGenre
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<VideoGame_Genre> VideoGame_Genres { get; set; }
    }
}
