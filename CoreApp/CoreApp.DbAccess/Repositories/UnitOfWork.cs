using System;
using System.Collections.Generic;
using System.Text;
using CoreApp.DbAccess.Context;
using CoreApp.DbAccess.Models;
using CoreApp.DbAccess.Repos;

namespace CoreApp.DbAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed;

        private IGenericRepository<Category> categoryRepository;
        private IGenericRepository<Product> bookRepository;
        private IGenericRepository<ProductType> productTypeRepository;
        private IGenericRepository<Unit> unitRepository;

        public UnitOfWork(IGenericRepository<> repository)
        {
        }


        public BookRepository Books
        {
            get
            {
                if (this.bookRepository == null)
                    this.bookRepository = new BookRepository(this.db);
                return this.bookRepository;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
