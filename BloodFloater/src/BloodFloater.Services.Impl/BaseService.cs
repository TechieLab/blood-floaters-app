using MongoDB.Bson;
using MongoDB.Driver;
using BloodFloater.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using BloodFloater.DAL;
using BloodFloater.Models;
using BloodFloater.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BloodFloater.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TSEntity">Source DomainModels</typeparam>
    /// <typeparam name="TDEntity">Destination View Models</typeparam>
    public abstract class BaseService<TSEntity, TDEntity> : IBaseService<TSEntity, TDEntity>
        where TSEntity : class, IBaseEntity, new() where TDEntity: class 
    {
        private readonly IBaseEntityRepository<TSEntity> _repository;

        #region Properties

        protected BaseService(IBaseEntityRepository<TSEntity> repository)
        {
            _repository = repository;
        }

        #endregion

        public virtual IEnumerable<TDEntity> Get()
        {
            return Mapper.Map<IEnumerable<TSEntity>, IEnumerable<TDEntity>>(_repository.Get());
        }

        public virtual Task<IEnumerable<TDEntity>> GetAsync()
        {
            return Mapper.Map<Task<IEnumerable<TSEntity>>, Task<IEnumerable<TDEntity>>>(_repository.GetAsync());
        }

        public virtual IEnumerable<TDEntity> AllIncluding(params Expression<Func<TSEntity, object>>[] includeProperties)
        {
            return Mapper.Map<IEnumerable<TSEntity>, IEnumerable<TDEntity>>(_repository.AllIncluding(includeProperties));
        }

        public virtual Task<IEnumerable<TDEntity>> AllIncludingAsync(
            params Expression<Func<TSEntity, object>>[] includeProperties)
        {
            return
                Mapper.Map<Task<IEnumerable<TSEntity>>, Task<IEnumerable<TDEntity>>>(
                    _repository.AllIncludingAsync(includeProperties));
        }

        public TDEntity Get(int id)
        {
            return Mapper.Map<TSEntity, TDEntity>(_repository.Get(id));
        }

        public Task<TDEntity> GetAsync(int id)
        {
            return Mapper.Map<Task<TSEntity>, Task<TDEntity>>(_repository.GetAsync(id));
        }

        public IEnumerable<TDEntity> Get(Expression<Func<TSEntity, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<TSEntity>, IEnumerable<TDEntity>>(_repository.Get(predicate));
        }

        public Task<IEnumerable<TDEntity>> GetAsync(Expression<Func<TSEntity, bool>> predicate)
        {
            return Mapper.Map<Task<IEnumerable<TSEntity>>, Task<IEnumerable<TDEntity>>>(_repository.GetAsync(predicate));
        }

        public TDEntity Get(Expression<Func<TSEntity, bool>> predicate,
            params Expression<Func<TSEntity, object>>[] includeProperties)
        {
            return Mapper.Map<TSEntity, TDEntity>(_repository.Get(predicate, includeProperties));
        }

        public Task<TDEntity> GetAsync(Expression<Func<TSEntity, bool>> predicate,
            params Expression<Func<TSEntity, object>>[] includeProperties)
        {
            return Mapper.Map<Task<TSEntity>, Task<TDEntity>>(_repository.GetAsync(predicate, includeProperties));
        }

        public virtual int Create(TSEntity entity)
        {
            return _repository.Add(entity);
        }

        public virtual int Update(TSEntity entity)
        {
            return _repository.Update(entity);
        }

        public virtual int Delete(int id)
        {
            var entity = Mapper.Map<TDEntity, TSEntity>(Get(id));
            return _repository.Delete(entity);
        }
    }
}
