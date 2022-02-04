using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.WebApi.ViewModels.GameGenresViewModel
{
    public class CreateGameGenreViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30, ErrorMessage = "Title should contains max 30 characters")]
        public string Title { get; set; }
    }
}
