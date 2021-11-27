using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Entities.Concrete;

namespace BookApp.WebUI.Models
{
    public class BookGenreModel
    {
        public Book Book { get; set; }
        public List<Genre> Categories { get; set; }
     
    }

}
