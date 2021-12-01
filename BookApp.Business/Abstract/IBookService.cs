using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Entities.Concrete;

namespace BookApp.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
        Book GetBookListWriter(int id);
        Book GetBookWithGenre(int id);
        List<Book> GetBookWithGenreId(int id);
        List<Book> GetSearchBooks(string s);
        List<Book> GetHighVote();

    }
}
