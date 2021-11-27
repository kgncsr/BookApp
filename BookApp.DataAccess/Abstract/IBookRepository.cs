using System.Collections.Generic;
using BookApp.DataAccess.Context;
using BookApp.Entities.Concrete;


namespace BookApp.DataAccess.Abstract
{
    public interface IBookRepository : IGenericRepository<Book,BookContext>
    {
        Book GetListWithWriter(int id);

        Book GetBookWithGenre(int id);
        List<Book> GetBooksByCategoryId(int id);
        List<Book> GetSearchBooks(string s);
    }
}
