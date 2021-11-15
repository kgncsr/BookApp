using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.DataAccess.Abstract;
using BookApp.DataAccess.Context;
using BookApp.Entities.Concrete;

namespace BookApp.DataAccess.Concrete.EntityFramework
{
    public class EfGenreRepository : EfGenericRepository<Genre,BookContext> , IGenreRepository
    {

    }
}
