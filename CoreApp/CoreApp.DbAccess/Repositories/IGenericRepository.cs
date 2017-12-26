﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CoreApp.DbAccess.Repos
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetRange(int start, int count);
        IEnumerable<TEntity> GetRange(int start, int count, Expression<Func<TEntity, bool>> predicate);

        int Count();

        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
