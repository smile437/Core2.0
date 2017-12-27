using System.Collections.Generic;
using CoreApp.DbAccess.Models;
using CoreApp.DbAccess.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly CategoryUOW unitUow;

        public CategoryController(CategoryUOW category)
        {
            this.unitUow = category;
        }

        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return this.unitUow.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public Category Get(int id)
        {
            return this.unitUow.Get(id);
        }
        
        // POST: api/Category
        [HttpPost]
        public void Post([FromBody]Category value)
        {
            this.unitUow.Add(value);
        }
        
        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Category value)
        {
            this.unitUow.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        { 
            this.unitUow.Remove(id);
        }
    }
}
