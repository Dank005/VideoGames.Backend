using AutoMapper;
using VideoGames.Domain;
using VideoGames.WebApi.ViewModels.GameGenresViewModel;
using VideoGames.WebApi.ViewModels.VideoGamesViewModel;

namespace VideoGames.Application.Common.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<GameGenre, GameGenreViewModel>().ReverseMap();
            CreateMap<CreateGameGenreViewModel, GameGenre>();
            CreateMap<VideoGame, VideoGameViewModel>().ReverseMap();
        }
    }
}
