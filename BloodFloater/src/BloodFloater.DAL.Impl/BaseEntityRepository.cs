using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BloodFloater.Models;

namespace BloodFloater.DAL.Impl
{
    public abstract class BaseEntityRepository<T> : IBaseEntityRepository<T>
            where T : class, IBaseEntity, new()
    {

        private readonly BloodFloaterContext _context;
        private readonly DbSet<T> _dbSet;

        #region Properties
        protected BaseEntityRepository(BloodFloaterContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        #endregion
        public virtual IEnumerable<T> Get()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public virtual async Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }
        public T Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual int Add(T entity)
        {
            _dbSet.Add(entity);
            Commit();

            return entity.Id;
        }

        public virtual int Update(T entity)
        {
            _dbSet.Attach(entity);
            var dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;

            return Commit();
        }
        public virtual int Delete(T entity)
        {
            _dbSet.Remove(entity);
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;

           return Commit();
        }

        public virtual int Commit()
        {
           return _context.SaveChanges();
        }
    }
}
