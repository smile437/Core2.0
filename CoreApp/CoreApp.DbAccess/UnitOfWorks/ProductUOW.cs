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
            var query = this.productRepository.GetAll(x => x.ProductType, x => x.Unit);
            var product= query.FirstOrDefault(p => p.Code == id);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var query = this.productRepository.GetAll(x => x.ProductType, x => x.Unit);
            return query.ToList();
        }

        //this method will display only available products
        public IEnumerable<Product> GetAvailable()
        {
            var query = this.productRepository.GetAll().Where(p => p.IsAvailable == true);
            return query.ToList();
        }

        //filter by type, category and entity
        public IEnumerable<Product> GetFilteringProducts(ProductFilter filteringParams)
        {
            var query = this.productRepository.GetAll(x => x.ProductType, x => x.Unit);

            if (filteringParams.FilterByType.Any())
                query = query.Where(x => filteringParams.FilterByType.Contains(x.ProductType.Description));

            if (filteringParams.FilterByCategory.Any())
                query = query.Where(x => x.Categories.Where(c => filteringParams.FilterByCategory.Contains(c.Category.Description)).Any());

            if (filteringParams.FilterByEntity.Any())
                query = query.Where(x => filteringParams.FilterByEntity.Contains(x.Description));

            return query;
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
