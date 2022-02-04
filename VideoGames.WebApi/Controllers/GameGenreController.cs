using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGames.Application.Interfaces;
using VideoGames.Domain;
using VideoGames.WebApi.ViewModels.GameGenresViewModel;

namespace VideoGames.WebApi.Controllers
{
    public class GameGenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GameGenreController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: GameGenreController/Index
        public async Task<IActionResult> Index()
        {
            var model = await _unitOfWork.GameGenre.GetAllAsync();
            var vm = _mapper.Map<List<GameGenreViewModel>>(model);
            return View(vm);
        }

        // GET: GameGenreController/Details
        public async Task<ActionResult> Details(Guid id)
        {
            var gamesOfGenre = await _unitOfWork.GameGenre.GetVideoGamesByGenreIdAsync(id);
            return View(gamesOfGenre);
        }

        // GET: GameGenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameGenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateGameGenreViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<GameGenre>(vm);
                await _unitOfWork.GameGenre.Insert(model);
                await _unitOfWork.SaveAsync();//
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: GameGenreController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _unitOfWork.GameGenre.GetByIdAsync(id);
            var vm = _mapper.Map<GameGenreViewModel>(model);
            return View(vm);
        }

        // POST: GameGenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GameGenreViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<GameGenre>(vm);
                _unitOfWork.GameGenre.Update(model);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: GameGenreController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var model = await _unitOfWork.GameGenre.GetByIdAsync(id);
            var vm = _mapper.Map<GameGenreViewModel>(model);
            return View(vm);
        }

        // POST: GameGenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(GameGenreViewModel vm)
        {
            var model = _mapper.Map<GameGenre>(vm);
            _unitOfWork.GameGenre.Delete(model);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
