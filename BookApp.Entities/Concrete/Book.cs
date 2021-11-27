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
        public decimal Vote { get; set; }
        public Writer Writer { get; set; }
        public int WriterId { get; set; }
        public List<BookGenre> BookGenres { get; set; }
    }
}
