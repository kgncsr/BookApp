using BookApp.DataAccess.Abstract;
using BookApp.DataAccess.Context;
using BookApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataAccess.Concrete.EntityFramework
{
    public class EfWriterRepository : EfGenericRepository<Writer, BookContext>, IWriterRepository
    {
        public List<Writer> GetBlogsByWriter(int id)
        {
            using (BookContext b = new())
            {
                return b.Writers.Include(a => a.Books).Where(a=>a.WriterId==id).ToList();
            }
        }
    }
}
