using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseApiController<TEntity> : Controller where TEntity : class
    {
        private readonly IBaseService<TEntity> _baseService;

        public BaseApiController(IBaseService<TEntity> baseService )
        {
            this._baseService = baseService;
        }

        // GET: api/values
        [HttpGet]
        public IList<TEntity> Get()
        {
            return _baseService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TEntity Get(ObjectId id)
        {
            return _baseService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TEntity value)
        {
            _baseService.Create(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(ObjectId id, [FromBody]TEntity value)
        {
            _baseService.Update(id,value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(ObjectId id)
        {
            _baseService.Delete(id);
        }
    }
}
