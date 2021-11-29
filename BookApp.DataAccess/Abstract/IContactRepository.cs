using BookApp.DataAccess.Context;
using BookApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataAccess.Abstract
{
    public interface IContactRepository : IGenericRepository<Contact,BookContext>
    {
    }
}
