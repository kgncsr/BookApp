using BookApp.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.ViewComponents
{
    public class BookWriterViewComponent : ViewComponent
    {
        private IWriterService _writerService;

        public BookWriterViewComponent(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _writerService.GetBlogsByWriter(id);
            return View(values);
        }
    }
}
