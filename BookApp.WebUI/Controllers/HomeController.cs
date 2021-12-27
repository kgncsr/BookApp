using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Business.Abstract;
using BookApp.WebUI.Models;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace BookApp.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }
      
        public IActionResult Index()
        {
            var books = _bookService.GetHighVote();
            var booksmodel = new BookListModel()
            {
                Books = books
            };
     
            return View(booksmodel);
        }

  
    }
}
