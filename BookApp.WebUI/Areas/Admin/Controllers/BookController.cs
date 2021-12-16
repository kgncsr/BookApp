using BookApp.Business.Abstract;
using BookApp.Entities.Concrete;
using BookApp.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IGenreService _genreService;
        private IWriterService _writerService;

        public BookController(IBookService bookService, IWriterService writerService, IGenreService genreService)
        {
            _genreService = genreService;
            _bookService = bookService;
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            
            var values = _bookService.GetAll();
            return View(values);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);
            _bookService.Delete(book);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> categoryValues = (from x in _writerService.GetAllList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.WriterId.ToString()
                                                   }).ToList();
            ViewBag.Cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookModel book)
        {
            Book values = new()
            {
                Title = book.Title,
                Description = book.Description,
                Vote = book.Vote,
                ImageUrl = book.ImageUrl,
                WriterId = book.WriterId
            };
            _bookService.Add(values);
            return RedirectToAction("List");
        }
    }
}
