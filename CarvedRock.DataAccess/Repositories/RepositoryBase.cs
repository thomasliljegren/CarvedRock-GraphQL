using CarvedRock.DataAccess.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarvedRock.DataAccess.Repositories
{

    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CarvedRockContext Context { get; set; }

        public RepositoryBase(CarvedRockContext context)
        {
            Context = context;
        }
        public void Create(T item)
        {
            Context.Set<T>().Add(item);
        }
        public void Update(T item)
        {
            Context.Set<T>().Update(item);
        }

        public void Delete(T item)
        {
            Context.Set<T>().Remove(item);
        }

        public IQueryable<T> FindAll()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

    }
}
