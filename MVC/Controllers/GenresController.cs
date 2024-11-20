using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class GenresController : MvcController
    {
        // Service injections:
        private readonly IGenresService _genresService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public GenresController(
			IGenresService genresService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _genresService = genresService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Genres
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _genresService.Query().ToList();
            return View(list);
        }

        // GET: Genres/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _genresService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BLL.Models.GenresModel genres)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _genresService.Create(genres.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = genres.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(genres);
        }

        // GET: Genres/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _genresService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Genres/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BLL.Models.GenresModel genres)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _genresService.Update(genres.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = genres.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(genres);
        }

        // GET: Genres/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _genresService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Genres/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _genresService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
