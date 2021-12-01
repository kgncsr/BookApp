using BookApp.Business.Abstract;
using BookApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IWriterService _writerService;

        public BookController(IBookService bookService, IWriterService writerService)
        {
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
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            return View();
        }
    }
}
