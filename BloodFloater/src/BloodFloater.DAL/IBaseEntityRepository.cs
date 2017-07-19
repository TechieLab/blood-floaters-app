using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BloodFloater.Models;

namespace BloodFloater.DAL
{
    public interface IBaseEntityRepository<T> where T : class , IBaseEntity, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> Get();

        Task<IEnumerable<T>> GetAsync();

        T Get(int id);

        Task<T> GetAsync(int id);

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        int Add(T entity);

        int Delete(T entity);

        int Update(T entity);

        int Commit();
    }
}
