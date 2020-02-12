using System;
using System.Linq;
using System.Linq.Expressions;
using WebApi.Models.Repository;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.DataManager
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected webApiContext _context { get; set; }

        public RepositoryBase(webApiContext webApiContext)
        {
            this._context = webApiContext;
        }

        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }
    }
}
