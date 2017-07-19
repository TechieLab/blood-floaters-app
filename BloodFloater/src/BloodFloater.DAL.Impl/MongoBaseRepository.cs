using MongoDB.Bson;
using MongoDB.Driver;
using BloodFloater.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.Core;

namespace BloodFloater.DAL.Impl
{
    public abstract class MongoBaseRepository<TEntity> : IMongoBaseRepository<TEntity> where TEntity : class
    {
        private IMongoCollection<TEntity> _mongoCollection;
        private readonly IMongoDbManager _mongoDbManager;

        protected MongoBaseRepository(IMongoDbManager dbManager)
        {
            _mongoDbManager = dbManager;
            dbManager.Connect("mongodb://localhost:27017");
            dbManager.SetDatabase("blood-floaterdb");
        }

        protected void SetCollection(IMongoCollection<TEntity> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public virtual Task Create(TEntity entity)
        {
            var result = _mongoCollection.InsertOneAsync(entity);

            return result;
        }

        public virtual Task Delete(ObjectId id)
        {
            var query = Builders<TEntity>.Filter.Eq("_id", id);
            return  _mongoCollection.DeleteOneAsync(query);
        }

        public virtual Task<TEntity> Get(ObjectId id)
        {
            var query = Builders<TEntity>.Filter.Eq("_id", id);
            var res = _mongoCollection.FindAsync(query);

            return res.Result.FirstOrDefaultAsync();
        }

        public virtual Task<List<TEntity>> Get(FilterDefinition<TEntity> filter, int? pageSize = 25, int? pageNumber = 1)
        {
            if (filter == null)
            {
                return _mongoCollection.AsQueryable().ToListAsync();
            }

            var list = _mongoCollection.FindAsync(filter).Result.ToListAsync();
            return list;
        }

        public virtual Task<TEntity> Update(ObjectId id, TEntity entity)
        {
            var query = Builders<TEntity>.Filter.Eq("_id", id);
            return _mongoCollection.FindOneAndReplaceAsync(query, entity);
        }

        public void Dispose()
        {
            _mongoDbManager.Disconnect();
        }
    }
}
