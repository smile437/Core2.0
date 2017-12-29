using System;
using System.Linq;
using System.Linq.Expressions;
using CoreApp.DbAccess.Context;
using CoreApp.DbAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.DbAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ProdDbContext context;
        private readonly DbSet<TEntity> entities;


        public GenericRepository(ProdDbContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return this.entities.Find(id);
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.entities.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);

            return query;
        }

        public IQueryable<TEntity> GetRange(int start, int count)
        {
            return this.entities.Skip(start).Take(count);
        }

        public IQueryable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate)
        {
            return this.entities.Where(predicate).Skip(start).Take(count);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.entities.Where(predicate);
        }

        public int Count()
        {
            return this.entities.Count();
        }

        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Remove(int id)
        {
            var entity = this.Get(id);
            this.context.Set<TEntity>().Remove(entity);
            this.Save();
        }

        public void Update(int id, TEntity entity)
        {
            this.context.Set<TEntity>().Update(entity);
            this.Save();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
