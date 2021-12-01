using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Business.Abstract;
using BookApp.DataAccess.Abstract;
using BookApp.DataAccess.Concrete.EntityFramework;
using BookApp.Entities.Concrete;

namespace BookApp.Business.Concrete
{
    public class BookManager : IBookService
    {
        private  IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAll()
        {
           return _bookRepository.GetAll();
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void Add(Book book)
        {
           _bookRepository.Add(book);
        }

        public void Delete(Book book)
        {
          _bookRepository.Delete(book);
        }

        public void Update(Book book)
        {
           _bookRepository.Update(book);
        }

        public Book GetBookListWriter(int id)
        {
            return _bookRepository.GetListWithWriter(id);
        }

        public Book GetBookWithGenre(int id)
        {
            return _bookRepository.GetBookWithGenre(id);
        }

        public List<Book> GetBookWithGenreId(int id)
        {
            return _bookRepository.GetBooksByCategoryId(id);
        }

        public List<Book> GetSearchBooks(string s)
        {
            return _bookRepository.GetSearchBooks(s);
        }

        public List<Book> GetHighVote()
        {
            return _bookRepository.GetHighVote();
        }


    }
}
