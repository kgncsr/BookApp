using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace BookApp.DataAccess.Abstract
{
    public interface IGenericRepository<O,OContext> 
    {
        void Add(O entity);
        void Delete(O entity);
        void Update(O entity);
        List<O> GetAll(Expression<Func<O, bool>> filter = null);
        O GetById(int id);
    }
}
