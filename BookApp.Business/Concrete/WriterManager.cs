using BookApp.Business.Abstract;
using BookApp.DataAccess.Abstract;
using BookApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private IWriterRepository _writerRepository;

        public WriterManager(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public List<Writer> GetAllList()
        {
            return _writerRepository.GetAll();
        }

        public List<Writer> GetBlogsByWriter(int id)
        {
           return _writerRepository.GetBlogsByWriter(id);
        }
    }
}
