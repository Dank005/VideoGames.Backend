using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.Domain
{
    public class VideoGame_Genre
    {
        public string VideoGameId { get; set; }
        public string GenreId { get; set; }

        public VideoGame VideoGame { get; set; }
        public GameGenre GameGenre { get; set; }
    }
}
