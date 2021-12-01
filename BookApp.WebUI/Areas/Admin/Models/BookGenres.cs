using BookApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Areas.Admin.Models
{
    public class BookGenres
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Vote { get; set; }
        public Writer Writer { get; set; }
        public int WriterId { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
