using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreApp.DbAccess.Interfaces;
using CoreApp.DbAccess.Models;

namespace CoreApp.DbAccess.UnitOfWorks
{
    public class ProductTypeUnitOfWork
    {
        private readonly IGenericRepository<ProductType> productTypeRepository;

        public ProductTypeUnitOfWork(IGenericRepository<ProductType> productTypeRepository)
        {
            this.productTypeRepository = productTypeRepository;
        }

        public ProductType Get(int id)
        {
            return this.productTypeRepository.Get(id);
        }

        public virtual IEnumerable<ProductType> GetAll()
        {
            var query = this.productTypeRepository.GetAll();
            return query.ToList();
        }

        public IEnumerable<ProductType> GetRange(int start, int count)
        {
            var query = this.productTypeRepository.GetRange(start, count);
            return query.ToList();
        }

        public IEnumerable<ProductType> GetRange(int start, int count, Expression<Func<ProductType, bool>> predicate)
        {
            var query = this.productTypeRepository.GetRange(start, count, predicate);
            return query.ToList();
        }

        public IEnumerable<ProductType> Find(Expression<Func<ProductType, bool>> predicate)
        {
            return this.productTypeRepository.Find(predicate);
        }

        public int Count()
        {
            return this.productTypeRepository.Count();
        }

        public virtual void Add(ProductType entity)
        {
            this.productTypeRepository.Add(entity);
            this.productTypeRepository.Save();
        }

        public virtual void Remove(ProductType entity)
        {
            this.productTypeRepository.Remove(entity);
            this.productTypeRepository.Save();
        }
    }
}
