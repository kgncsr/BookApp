using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.DataAccess.Abstract;
using BookApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace BookApp.DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<O, OContext> : IGenericRepository<O, OContext> where O : class
        where OContext : BookContext, new()
    {


        public void Add(O entity)
        {
            using (var context = new OContext())
            {
                context.Set<O>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(O entity)
        {
            using (var context = new OContext())
            {
                context.Set<O>().Remove(entity);
                context.SaveChanges();
            }
        }

        public List<O> GetAll(System.Linq.Expressions.Expression<Func<O, bool>> filter = null)
        {
            using (var context = new OContext())
            {
                return filter == null
                    ? context.Set<O>().ToList()
                    : context.Set<O>().Where(filter).ToList();
            }
        }

        public O GetById(int id)
        {
            using (var context = new OContext())
            {
                return context.Set<O>().Find(id);
            }

        }

        public void Update(O entity)
        {
            using (var context = new OContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
