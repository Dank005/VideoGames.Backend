using System;
using System.ComponentModel.DataAnnotations;

namespace VideoGames.WebApi.ViewModels.GameGenresViewModel
{
    public class GameGenreViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30, ErrorMessage = "Title should contains max 30 characters")]
        public string Title { get; set; }
    }
}
