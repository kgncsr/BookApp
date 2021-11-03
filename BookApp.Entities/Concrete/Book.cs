using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Entities.Concrete
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
