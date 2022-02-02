using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public IActionResult Index()
        {
            var model = _unitOfWork.GameGenre.GetAll();
            var vm = _mapper.Map<List<GameGenreViewModel>>(model);
            return View(vm);
        }

        public ActionResult Details(Guid id)
        {
            var gamesOfGenre = _unitOfWork.GameGenre.GetVideoGamesByGenreId(id);
            return View(gamesOfGenre);
            //нужна viewModel
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: GameGenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGameGenreViewModel vm)
        {
            try
            {
                var model = _mapper.Map<GameGenre>(vm);
                _unitOfWork.GameGenre.Insert(model);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: GameGenreController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _unitOfWork.GameGenre.GetById(id);
            var vm = _mapper.Map<GameGenreViewModel>(model);
            return View(vm);
        }

        // POST: GameGenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameGenreViewModel vm)
        {
            try
            {
                var model = _mapper.Map<GameGenre>(vm);
                _unitOfWork.GameGenre.Update(model);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameGenreController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _unitOfWork.GameGenre.GetById(id);
            var vm = _mapper.Map<GameGenreViewModel>(model);
            return View(vm);
        }

        // POST: GameGenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GameGenreViewModel vm)
        {
            try
            {
                var model = _mapper.Map<GameGenre>(vm);
                _unitOfWork.GameGenre.Delete(model);
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
