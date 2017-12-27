using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoreApp.DbAccess.Interfaces;
using CoreApp.DbAccess.Models;

namespace CoreApp.DbAccess.UnitOfWorks
{
    public class ProductUOW
    {
        private readonly IGenericRepository<Product> productRepository;

        public ProductUOW(IGenericRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Get(int id)
        {
            return this.productRepository.Get(id);
        }

        public virtual IEnumerable<Product> GetAll()
        {
            var query = this.productRepository.GetAll();
            return query.ToList();
        }

        public IEnumerable<Product> GetRange(int start, int count)
        {
            var query = this.productRepository.GetRange(start, count);
            return query.ToList();
        }

        public IEnumerable<Product> GetRange(int start, int count, Expression<Func<Product, bool>> predicate)
        {
            var query =  this.productRepository.GetRange(start, count, predicate);
            return query.ToList();
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            return this.productRepository.Find(predicate);
        }

        public int Count()
        {
            return this.productRepository.Count();
        }

        public virtual void Add(Product entity)
        {
            this.productRepository.Add(entity);
            this.productRepository.Save();
        }

        public virtual void Remove(int id)
        {
            this.productRepository.Remove(id);
            this.productRepository.Save();
        }

        public void Update(int id, Product entity)
        {
            this.productRepository.Update(id, entity);
        }
    }
}
