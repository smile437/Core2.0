using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoreApp.DbAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetRange(int start, int count);
        IQueryable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate);

        int Count();
        void Save();
        void Add(TEntity entity);
        void Remove(int id);
        void Update(int id, TEntity entity);
    }
}
