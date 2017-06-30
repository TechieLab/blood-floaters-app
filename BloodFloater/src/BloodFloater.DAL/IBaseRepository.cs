using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodFloater.DAL
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Get(ObjectId id);

        List<TEntity> GetAll();

        void Create(TEntity entity);

        bool Delete(ObjectId id);

        void Update(ObjectId id, TEntity entity);
    }
}
