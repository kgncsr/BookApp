using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Business.Abstract;
using BookApp.DataAccess.Abstract;
using BookApp.Entities.Concrete;

namespace BookApp.Business.Concrete
{
    public class GenreManager : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreManager(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public List<Genre> GetAllList()
        {
            return _genreRepository.GetAll();
        }

        public Genre GetById(int id)
        {
            return _genreRepository.GetById(id);
        }

        public void Add(Genre genre)
        {
            _genreRepository.Add(genre);
        }

        public void Delete(Genre genre)
        {
            _genreRepository.Delete(genre);
        }

        public void Update(Genre genre)
        {
            _genreRepository.Update(genre);
        }
    }
}
