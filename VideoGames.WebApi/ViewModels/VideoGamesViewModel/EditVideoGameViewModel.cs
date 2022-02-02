using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.WebApi.ViewModels.VideoGamesViewModel
{
    public class EditVideoGameViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DeveloperStudio { get; set; }
        public List<SelectListItem> GameGenres { get; set; }
        public string[] SelectedGenres { get; set; }
    }
}
