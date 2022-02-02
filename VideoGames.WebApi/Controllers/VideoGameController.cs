using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;
using VideoGames.Persistence;
using VideoGames.WebApi.ViewModels.VideoGamesViewModel;

namespace VideoGames.WebApi.Controllers
{
    public class VideoGameController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public VideoGameController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.VideoGame.GetAll();
            var vm = _mapper.Map<List<VideoGameViewModel>>(model);
            return View(vm);
        }

        public ActionResult Details(Guid id)
        {
            var genres = _unitOfWork.VideoGame.GetGenresByVideoGameId(id);
            return View(genres);
            //нужна viewModel
        }

        public ActionResult Create()
        {
            var allGenres = _unitOfWork.GameGenre.GetAll();
            var selectedList = new List<SelectListItem>();
            foreach (var genre in allGenres)
            {
                selectedList.Add(new SelectListItem(genre.Title, genre.Id.ToString()));
            }
            var vm = new CreateVideoGameViewModel()
            {
                GameGenres = selectedList
            };

            return View(vm);
        }

        // POST: VideoGameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateVideoGameViewModel vm)
        {
            try
            {
                VideoGame videoGame = new VideoGame()
                {
                    Title = vm.Title,
                    DeveloperStudio = vm.DeveloperStudio
                };
                foreach (var item in vm.SelectedGenres)
                {
                    videoGame.VideoGame_Genres.Add(new VideoGame_Genre()
                    {
                        GameGenreId = new Guid(item)
                    });
                }
                _unitOfWork.VideoGame.Insert(videoGame);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoGameController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var videoGame = _unitOfWork.VideoGame.GetById(id);
            var gameGenres = _unitOfWork.GameGenre.GetAll();
            var selectedGameGenres = videoGame.VideoGame_Genres.Select(x => new GameGenre()
            {
                Id = x.GameGenre.Id,
                Title = x.GameGenre.Title
            });
            var selecedList = new List<SelectListItem>();
            gameGenres.ForEach(i => selecedList.Add(new SelectListItem(i.Title, i.Id.ToString(), selectedGameGenres.Select(x => x.Id).Contains(i.Id))));
            var vm = new EditVideoGameViewModel()
            {
                Id = videoGame.Id,
                Title = videoGame.Title,
                DeveloperStudio = videoGame.DeveloperStudio,
                GameGenres = selecedList
            };
            return View(vm);
        }

        // POST: VideoGameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditVideoGameViewModel vm)
        {
            try
            {
                var videoGame = _unitOfWork.VideoGame.GetById(vm.Id);
                videoGame.Title = vm.Title;
                videoGame.DeveloperStudio = vm.DeveloperStudio;
                var selectedGameGenres = vm.SelectedGenres;
                var existingGameGenres = videoGame.VideoGame_Genres.Select(x => x.GameGenreId.ToString()).ToList();
                var toAdd = selectedGameGenres.Except(existingGameGenres).ToList();
                var toRemove = existingGameGenres.Except(selectedGameGenres).ToList();
                videoGame.VideoGame_Genres = videoGame.VideoGame_Genres.Where(x => !toRemove.Contains(x.GameGenreId.ToString())).ToList();
                foreach (var item in toAdd)
                {
                    videoGame.VideoGame_Genres.Add(new VideoGame_Genre()
                    {
                        GameGenreId = new Guid(item),
                        VideoGameId = videoGame.Id
                    });
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoGameController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var videoGame = _unitOfWork.VideoGame.GetById(id);
            var vm = _mapper.Map<VideoGameViewModel>(videoGame);
            return View(vm);
        }

        // POST: VideoGameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VideoGameViewModel vm)
        {
            try
            {
                var videoGame = _mapper.Map<VideoGame>(vm);
                _unitOfWork.VideoGame.Delete(videoGame);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
