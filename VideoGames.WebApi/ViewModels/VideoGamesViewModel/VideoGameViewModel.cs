using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGames.Domain;

namespace VideoGames.WebApi.ViewModels.VideoGamesViewModel
{
    public class VideoGameViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30, ErrorMessage = "Title should contains max 30 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "DeveloperStudio is required")]
        [MaxLength(50, ErrorMessage = "DeveloperStudio should contains max 50 characters")]
        public string DeveloperStudio { get; set; }

        public List<VideoGame_Genre> VideoGame_Genres { get; set; }
    }
}
