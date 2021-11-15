using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.DataAccess.Abstract;
using BookApp.DataAccess.Context;
using BookApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookApp.DataAccess.Concrete.EntityFramework
{
    public class EfBookRepository : EfGenericRepository<Book,BookContext>,IBookRepository
    {
        public Book GetListWithWriter(int id)
        {
            using (BookContext bookContext = new())
            {
                return bookContext.Books.Include(x => x.Writer).Where(x => x.BookId == id).FirstOrDefault();
            }
        }

        public Book GetBookWithGenre(int id)
        {
            using (BookContext bookContext = new())
            {
                return bookContext.Books
                    .Where(i => i.BookId == id)
                    .Include(i => i.BookGenres)
                    .ThenInclude(i => i.Genre)
                    .FirstOrDefault();
            }
        }
    }
}
