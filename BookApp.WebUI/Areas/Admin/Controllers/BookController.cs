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
        public IActionResult Index()
        {
            return View();
        }
    }
}
