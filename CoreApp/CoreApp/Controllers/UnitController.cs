using System.Collections.Generic;
using CoreApp.DbAccess.Models;
using CoreApp.DbAccess.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Unit")]
    public class UnitController : Controller
    {
        private readonly UnitUOW unitUow;

        public UnitController(UnitUOW unit)
        {
            this.unitUow = unit;
        }

        // GET: api/Unit
        [HttpGet]
        public IEnumerable<Unit> Get()
        {
            return this.unitUow.GetAll();
        }

        // GET: api/Unit/5
        [HttpGet("{id}", Name = "Get")]
        public Unit Get(int id)
        {
            return this.unitUow.Get(id);
        }

        // POST: api/Unit
        [HttpPost]
        public void Post([FromBody]Unit value)
        {
            this.unitUow.Add(value);
        }

        // PUT: api/Unit/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Unit value)
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
