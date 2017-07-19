using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace BloodFloater.DAL
{
    public interface IMongoBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Get(ObjectId id);

        Task<List<TEntity>> Get(FilterDefinition<TEntity> filter, int? pageSize = 25, int? pageNumber = 1);

        Task Create(TEntity entity);

        Task Delete(ObjectId id);

        Task<TEntity> Update(ObjectId id, TEntity entity);
    }
}
