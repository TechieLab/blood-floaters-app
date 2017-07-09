using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloodFloater.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BloodFloater.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    [EnableCors("CorsPolicy")]
    public class BaseApiController<TSEntity, TDEntity> : Controller where TSEntity : class where TDEntity : class
    {
        private readonly IBaseService<TSEntity> _baseService;

        public BaseApiController(IBaseService<TSEntity> baseService )
        {
            this._baseService = baseService;
        }

        // GET: api/values
        [HttpGet]
        public IList<TDEntity> Get()
        {
            return Mapper.Map<List<TSEntity>,List<TDEntity>>(_baseService.Get(null));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TDEntity Get(ObjectId id)
        {
            return Mapper.Map<TSEntity, TDEntity>(_baseService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TDEntity value)
        {
            _baseService.Create(Mapper.Map<TDEntity, TSEntity>(value));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(ObjectId id, [FromBody]TDEntity value)
        {
            _baseService.Update(id, Mapper.Map<TDEntity, TSEntity>(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(ObjectId id)
        {
            _baseService.Delete(id);
        }
    }
}
