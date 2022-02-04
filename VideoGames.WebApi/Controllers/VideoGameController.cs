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

        // GET: VideoGameController/Index
        public async Task<ActionResult> Index()
        {
            var model = await _unitOfWork.VideoGame.GetAllAsync();
            var vm = _mapper.Map<List<VideoGameViewModel>>(model);
            return View(vm);
        }

        // GET: VideoGameController/Details
        public async Task<ActionResult> Details(Guid id)
        {
            var genres = await _unitOfWork.VideoGame.GetGenresByVideoGameIdAsync(id);
            return View(genres);
        }

        // GET: VideoGameController/Create
        public async Task<ActionResult> Create()
        {
            var selectedList = await GetGenersListForSelect();
            var vm = new CreateVideoGameViewModel() { GameGenres = selectedList };
            return View(vm);
        }

        // POST: VideoGameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateVideoGameViewModel vm)
        {
            if (ModelState.IsValid)
            {
                VideoGame videoGame = new VideoGame()
                {                   
                    Title = vm.Title,
                    DeveloperStudio = vm.DeveloperStudio
                };
                if (vm.SelectedGenres != null)
                    AddSelectedGenres(vm, videoGame);

                await _unitOfWork.VideoGame.Insert(videoGame);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: VideoGameController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var videoGame = await _unitOfWork.VideoGame.GetGenresByVideoGameIdAsync(id);
            var selecedList = await GetSelectedGenres(videoGame);
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
        public async Task<ActionResult> Edit(EditVideoGameViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var videoGame = await _unitOfWork.VideoGame.GetGenresByVideoGameIdAsync(vm.Id);
                videoGame.Title = vm.Title;
                videoGame.DeveloperStudio = vm.DeveloperStudio;
                TransformSelectedGenres(vm, videoGame);

                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
       
        // GET: VideoGameController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var videoGame = await _unitOfWork.VideoGame.GetByIdAsync(id);
            var vm = _mapper.Map<VideoGameViewModel>(videoGame);
            return View(vm);
        }

        // POST: VideoGameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(VideoGameViewModel vm)
        {
            var videoGame = _mapper.Map<VideoGame>(vm);
            _unitOfWork.VideoGame.Delete(videoGame);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<List<SelectListItem>> GetGenersListForSelect()
        {
            var allGenres = await _unitOfWork.GameGenre.GetAllAsync();
            var selectedList = new List<SelectListItem>();
            foreach (var genre in allGenres)
            {
                selectedList.Add(new SelectListItem(genre.Title, genre.Id.ToString()));
            }
            return selectedList;
        }

        private static void AddSelectedGenres(CreateVideoGameViewModel vm, VideoGame videoGame)
        {
            foreach (var item in vm.SelectedGenres)
            {
                videoGame.VideoGame_Genres.Add(new VideoGame_Genre()
                {
                    GameGenreId = new Guid(item)
                });
            }
        }

        private async Task<List<SelectListItem>> GetSelectedGenres(VideoGame videoGame)
        {
            var selectedGameGenres = videoGame.VideoGame_Genres.Select(x => new GameGenre()
            {
                Id = x.GameGenre.Id,
                Title = x.GameGenre.Title
            });
            var gameGenres = await _unitOfWork.GameGenre.GetAllAsync();
            var selecedList = new List<SelectListItem>();
            if (gameGenres.Count > 0)
                gameGenres.ForEach(i => selecedList.Add(new SelectListItem(i.Title, i.Id.ToString(),
                    selectedGameGenres.Select(x => x.Id).Contains(i.Id))));
            return selecedList;
        }

        private static void TransformSelectedGenres(EditVideoGameViewModel vm, VideoGame videoGame)
        {
            var selectedGameGenres = vm.SelectedGenres;
            var existingGameGenres = videoGame.VideoGame_Genres.Select(x => x.GameGenreId.ToString()).ToList();

            //genres for add
            var toAdd = new List<string>();
            if (selectedGameGenres != null)
                toAdd = selectedGameGenres.Except(existingGameGenres).ToList();

            //gernres for remove
            var toRemove = new List<string>();
            if (existingGameGenres.Count != 0)
            {
                if (selectedGameGenres != null)
                    toRemove = existingGameGenres.Except(selectedGameGenres).ToList();
                else
                    toRemove = existingGameGenres;
            }

            //delete unselected genres
            videoGame.VideoGame_Genres = videoGame.VideoGame_Genres.Where(x => !toRemove.Contains(x.GameGenreId.ToString())).ToList();

            //add new genres
            if (toAdd.Count > 0)
            {
                foreach (var item in toAdd)
                {
                    videoGame.VideoGame_Genres.Add(new VideoGame_Genre()
                    {
                        GameGenreId = new Guid(item),
                        VideoGameId = videoGame.Id
                    });
                }
            }
        }

    }
}
