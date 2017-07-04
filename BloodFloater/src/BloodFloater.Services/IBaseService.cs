using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace BloodFloater.Services
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        TEntity Get(ObjectId id);

        List<TEntity> Get(FilterDefinition<TEntity> filter, int? pageSize = 25, int? pageNumber = 1);

        void Create(TEntity entity);

        bool Delete(ObjectId id);

        void Update(ObjectId id ,TEntity entity);
    }
}
