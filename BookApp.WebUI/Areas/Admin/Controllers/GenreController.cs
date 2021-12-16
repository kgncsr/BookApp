using BookApp.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class GenreController : Controller
    {
        IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var result = _genreService.GetAllList();
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _genreService.GetById(id);
            _genreService.Delete(result);
            return RedirectToAction("List");
        }
    }
}
