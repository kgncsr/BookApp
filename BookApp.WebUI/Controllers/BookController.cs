using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Business.Abstract;
using BookApp.WebUI.Models;
using Microsoft.AspNetCore.Mvc;


namespace BookApp.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Details(int id)
        {
           var bookwriter =  _bookService.GetBookListWriter(id);
           var bookgenre = _bookService.GetBookWithGenre(id).BookGenres.Select(i => i.Genre).ToList();

           return View(new BookGenreModel
           {
               Book = bookwriter,
               Categories = bookgenre
           });
        }
    }
}
