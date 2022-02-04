using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VideoGames.WebApi.ViewModels.VideoGamesViewModel
{
    public class CreateVideoGameViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30, ErrorMessage = "Title should contains max 30 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "DeveloperStudio is required")]
        [MaxLength(50, ErrorMessage = "DeveloperStudio should contains max 50 characters")]
        public string DeveloperStudio { get; set; }

        public List<SelectListItem> GameGenres { get; set; }

        public string[] SelectedGenres { get; set; }
    }
}
