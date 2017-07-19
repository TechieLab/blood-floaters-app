using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BloodFloater.ViewModels;
using MongoDB.Driver;

namespace BloodFloater.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSEntity">Source DomainModels</typeparam>
    /// <typeparam name="TDEntity">Destination View Models</typeparam>
    public interface IBaseService<TSEntity, TDEntity> where TSEntity : class where TDEntity : class
    {

        IEnumerable<TDEntity> AllIncluding(params Expression<Func<TSEntity, object>>[] includeProperties);

        Task<IEnumerable<TDEntity>> AllIncludingAsync(params Expression<Func<TSEntity, object>>[] includeProperties);

        IEnumerable<TDEntity> Get();

        Task<IEnumerable<TDEntity>> GetAsync();

        TDEntity Get(int id);

        Task<TDEntity> GetAsync(int id);

        IEnumerable<TDEntity> Get(Expression<Func<TSEntity, bool>> predicate);

        Task<IEnumerable<TDEntity>> GetAsync(Expression<Func<TSEntity, bool>> predicate);

        TDEntity Get(Expression<Func<TSEntity, bool>> predicate, params Expression<Func<TSEntity, object>>[] includeProperties);

        Task<TDEntity> GetAsync(Expression<Func<TSEntity, bool>> predicate, params Expression<Func<TSEntity, object>>[] includeProperties);
        
        int Create(TSEntity entity);

        int Delete(int id);

        int Update(TSEntity entity);
    }
}
