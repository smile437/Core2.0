using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreApp.DbAccess.Interfaces;
using CoreApp.DbAccess.Models;

namespace CoreApp.DbAccess.UnitOfWorks
{
    public class CategoryUOW
    {
        private readonly IGenericRepository<Category> unitRepository;

        public CategoryUOW(IGenericRepository<Category> unitRepository)
        {
            this.unitRepository = unitRepository;
        }

        public Category Get(int id)
        {
            return this.unitRepository.Get(id);
        }

        public virtual IEnumerable<Category> GetAll()
        {
            var query = this.unitRepository.GetAll();
            return query.ToList();
        }

        public IEnumerable<Category> GetRange(int start, int count)
        {
            var query = this.unitRepository.GetRange(start, count);
            return query.ToList();
        }

        public IEnumerable<Category> GetRange(int start, int count, Expression<Func<Category, bool>> predicate)
        {
            var query = this.unitRepository.GetRange(start, count, predicate);
            return query.ToList();
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            return this.unitRepository.Find(predicate);
        }

        public int Count()
        {
            return this.unitRepository.Count();
        }

        public virtual void Add(Category entity)
        {
            this.unitRepository.Add(entity);
            this.unitRepository.Save();
        }

        public virtual void Remove(int id)
        {
            this.unitRepository.Remove(id);
            this.unitRepository.Save();
        }

        public void Update(int id, Category entity)
        {
            this.unitRepository.Update(id,entity);
        }
    }
}
