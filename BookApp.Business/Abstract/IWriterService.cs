using BookApp.DataAccess.Abstract;
using BookApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Business.Abstract
{
    public interface IWriterService
    {


        List<Writer> GetBlogsByWriter(int id);
        List<Writer> GetAllList();

    }
}
