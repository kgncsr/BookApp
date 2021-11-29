using BookApp.DataAccess.Abstract;
using BookApp.DataAccess.Context;
using BookApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataAccess.Concrete.EntityFramework
{
    public class EfContactRepository : EfGenericRepository<Contact, BookContext>,IContactRepository
    {
    }
}
