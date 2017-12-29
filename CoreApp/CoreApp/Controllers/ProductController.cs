using System.Collections.Generic;
using System.Linq;
using CoreApp.Currency.Core;
using CoreApp.DbAccess.Models;
using CoreApp.DbAccess.UnitOfWorks;
using CoreApp.RequestModels;
using CoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly ProductUOW productUow;

        public ProductController(ProductUOW product)
        {
            this.productUow = product;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return this.productUow.GetAll();
        }


        // method that returns available products(with pagination)
        [HttpGet("available")]
        public IActionResult GetAvailable(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var products = this.productUow.GetAvailable();
            var count = products.Count();
            var items = products.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var pageViewModel = new PageViewModel(count, pageNumber, pageSize);
            var viewModel = new IndexViewModel { PageViewModel = pageViewModel, Products = items };

            return Ok(viewModel);
        }

        [HttpGet("filter")]
        public IEnumerable<Product> GetFilteringProducts(ProductFilteringParams filteringParams)
        {
            return this.productUow.GetFilteringProducts(filteringParams);
        }

        [HttpGet("format/{id}",Name ="GetFormat")]
        //[Route("api/Product/Format")]
        public ProductFormatedViewModel GetProductInFormat(int id)
        {
            // TODO: provide a factory that should retrieve a strategy 
            // depending on either a parameter received from clients 
            // or an appropriete HTTP header
            var product = this.productUow.Get(id);
            return new ProductFormatedViewModel(product, new ZlotyExchangeStrategy());
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return this.productUow.Get(id);
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]Product value)
        {
            this.productUow.Add(value);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product value)
        {
            this.productUow.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.productUow.Remove(id);
        }
    }
}
