using System.Collections.Generic;
using CoreApp.DbAccess.Models;
using CoreApp.DbAccess.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductType")]
    public class ProductTypeController : Controller
    {
        private readonly ProductTypeUOW productTypeUow;

        public ProductTypeController(ProductTypeUOW productType)
        {
            this.productTypeUow = productType;
        }

        // GET: api/ProductType
        [HttpGet]
        public IEnumerable<ProductType> Get()
        {
            return this.productTypeUow.GetAll();
        }

        // GET: api/ProductType/5
        //[HttpGet("{id}", Name = "Get")]
        public ProductType Get(int id)
        {
            return this.productTypeUow.Get(id);
        } 

        // POST: api/ProductType
        [HttpPost]
        public void Post([FromBody]ProductType value)
        {
            this.productTypeUow.Add(value);
        }

        // PUT: api/ProductType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProductType value)
        {
            this.productTypeUow.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.productTypeUow.Remove(id);
        }
    }
}
