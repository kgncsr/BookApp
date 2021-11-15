using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Entities.Concrete
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<BookGenre> BookGenres { get; set; }
    }
}
