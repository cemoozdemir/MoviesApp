﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;
using BLL.DAL;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Authorization;

// Generated from Custom Template.

namespace MVC.Controllers
{
    [Authorize]
    public class MoviesController : MvcController
    {
        // Service injections:
        private readonly IService<Movie, MovieModel> _movieService;
        private readonly IService<Director, DirectorModel> _directorService;
        // Many to many relationships service injections:
        private readonly IService<Genres, GenresModel> _genresService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IService _ManyToManyRecordService;

        public MoviesController(
            IService<Movie, MovieModel> movieService
            , IService<Director, DirectorModel> directorService
            // Many to many relationships service injections:
            , IService<Genres, GenresModel> genresService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _movieService = movieService;
            _directorService = directorService;
            // Many to many relationships service injections:
            _genresService = genresService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Movies
        [AllowAnonymous]
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _movieService.Query().ToList();
            return View(list);
        }

        // GET: Movies/Details/5
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _movieService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["DirectorId"] = new SelectList(_directorService.Query().ToList(), "Record.Id", "Name");

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            ViewBag.GenreIds = new MultiSelectList(_genresService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Movies/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _movieService.Create(movie.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = movie.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _movieService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Movies/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _movieService.Update(movie.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = movie.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _movieService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Movies/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _movieService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
