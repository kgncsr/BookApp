using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Entities.Concrete
{
    public class Writer
    {
        public int WriterId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }

    }
}
