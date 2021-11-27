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
        private readonly IWriterService _writerService;



        public BookController(IBookService bookService, IWriterService writerService)
        {
            _writerService = writerService;
            _bookService = bookService;
        }
        public IActionResult Details(int id)
        {
            if (id==0)
            {
                return NotFound();
            }
            else
            {
                var bookwriter = _bookService.GetBookListWriter(id);             
                var bookgenre = _bookService.GetBookWithGenre(id).BookGenres.Select(i => i.Genre).ToList();

                return View(new BookGenreModel
                {
                    Book = bookwriter,
                    Categories = bookgenre,               
                });;
            }

        }

        public IActionResult AllList(int id)
        {

            var values = _bookService.GetBookWithGenreId(id);
            return View(values);
        }

        public IActionResult Search(string s)
        {
            var values = _bookService.GetSearchBooks(s);
            BookListModel models = new()
            {
                Books = values
            };
            return View(values);
        }

        public IActionResult BookWriter()
        {
           var values =  _writerService.GetBlogsByWriter(1);
            return View(values);
        }

    }
}
