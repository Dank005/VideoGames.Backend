using System;
using System.Collections.Generic;

namespace VideoGames.Domain
{
    public class VideoGame
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DeveloperStudio { get; set; }
        public List<VideoGame_Genre> VideoGame_Genres { get; set; } = new List<VideoGame_Genre>();
    }
}
