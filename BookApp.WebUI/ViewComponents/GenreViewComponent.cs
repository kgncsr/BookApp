using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace BookApp.WebUI.ViewComponents
{
    public class GenreViewComponent :ViewComponent
    {
        private IGenreService _genreService;
                                                                                            
        public GenreViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }


        public IViewComponentResult Invoke()
        {
            ViewBag.Selected = RouteData.Values["id"];
            return View(_genreService.GetAllList());
        }
    }
}
