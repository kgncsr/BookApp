using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.DataAccess.Context;
using BookApp.Entities.Concrete;

namespace BookApp.DataAccess.Abstract
{
    public interface IGenreRepository : IGenericRepository<Genre, BookContext>
    {

    }
}
