using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.Core
{
   public interface IMongoDbManager
    {
        IMongoDatabase GetDatabase(string dbName);

        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName);

        void SetDatabase(string dbName);

        void Connect(string dbUrl);
    }
}
