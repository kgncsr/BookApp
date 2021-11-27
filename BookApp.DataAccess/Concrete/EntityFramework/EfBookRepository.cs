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

        public List<Book> GetBooksByCategoryId(int id)
        {
            using (BookContext bookContext = new())
            {
                return bookContext.Books
                    .Include(a => a.BookGenres)
                    .ThenInclude(a => a.Genre).Where(a => a.BookGenres.Any(a => a.GenreId == id)).ToList();
            }
        }

        public List<Book> GetSearchBooks(string s)
        {
            using (BookContext bookContext = new())
            {
               var  books = bookContext.Books.Where(i =>
                  i.Title.ToLower().Contains(s.ToLower()) ||
                  i.Description.ToLower().Contains(s.ToLower())).ToList();
                return books;
            }
        }


    }
}
