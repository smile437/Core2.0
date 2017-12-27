using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreApp.DbAccess.Interfaces;
using CoreApp.DbAccess.Models;

namespace CoreApp.DbAccess.UnitOfWorks
{
    public class UnitUnitOfWork
    {
        private readonly IGenericRepository<Unit> unitRepository;

        public UnitUnitOfWork(IGenericRepository<Unit> unitRepository)
        {
            this.unitRepository = unitRepository;
        }

        public Unit Get(int id)
        {
            return this.unitRepository.Get(id);
        }

        public virtual IEnumerable<Unit> GetAll()
        {
            var query = this.unitRepository.GetAll();
            return query.ToList();
        }

        public IEnumerable<Unit> GetRange(int start, int count)
        {
            var query = this.unitRepository.GetRange(start, count);
            return query.ToList();
        }

        public IEnumerable<Unit> GetRange(int start, int count, Expression<Func<Unit, bool>> predicate)
        {
            var query = this.unitRepository.GetRange(start, count, predicate);
            return query.ToList();
        }

        public IEnumerable<Unit> Find(Expression<Func<Unit, bool>> predicate)
        {
            return this.unitRepository.Find(predicate);
        }

        public int Count()
        {
            return this.unitRepository.Count();
        }

        public virtual void Add(Unit entity)
        {
            this.unitRepository.Add(entity);
            this.unitRepository.Save();
        }

        public virtual void Remove(Unit entity)
        {
            this.unitRepository.Remove(entity);
            this.unitRepository.Save();
        }
    }
}
