using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreApp.DbAccess.Context;
using CoreApp.DbAccess.Interfaces;

namespace CoreApp.DbAccess.Repos
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly DbSet<TEntity> entities;
        private ProdDbContext context;


        protected GenericRepository(ProdDbContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return this.entities.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return this.entities;
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count)
        {
            return this.entities.Skip(start).Take(count);
        }

        public virtual IQueryable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate)
        {
            return this.entities.Where(predicate).Skip(start).Take(count);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.entities.Where(predicate);
        }

        public virtual int Count()
        {
            return this.entities.Count();
        }

        public virtual void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
