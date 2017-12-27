using System.Collections.Generic;
using CoreApp.DbAccess.Models;
using CoreApp.DbAccess.UnitOfWorks;
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
