using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.Domain;

namespace VideoGames.WebApi.ViewModels.VideoGamesViewModel
{
    public class VideoGameViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DeveloperStudio { get; set; }
        public List<VideoGame_Genre> VideoGame_Genres { get; set; }
    }
}
