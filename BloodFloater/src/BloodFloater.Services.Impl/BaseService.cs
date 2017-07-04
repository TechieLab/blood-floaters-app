using MongoDB.Bson;
using MongoDB.Driver;
using BloodFloater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.DAL;

namespace BloodFloater.Services.Impl
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {        
        private readonly IBaseRepository<TEntity> _repository;

        protected BaseService(IBaseRepository<TEntity> repository)
        {   
            _repository = repository;
        }

        public void Create(TEntity entity)
        {
            _repository.Create(entity);
        }

        public bool Delete(ObjectId id)
        {
            return _repository.Delete(id);
        }

        public TEntity Get(ObjectId id)
        {
            return _repository.Get(id);
        }

        public List<TEntity> Get(FilterDefinition<TEntity> filter, int? pageSize = 25, int? pageNumber = 1)
        {
            return _repository.Get(filter, pageSize, pageNumber);
        }

        public void Update(ObjectId id, TEntity entity)
        {
            _repository.Update(id,entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
