using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity> where TEntity : class
        where TContext : DbContext
    {
        #region Private Members

        private readonly TContext _dbContext;

        #endregion

        #region Protected Members

        protected virtual TContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        protected virtual DbSet<TEntity> DbSet => DbContext.Set<TEntity>();

        #endregion

        #region Constructor

        public RepositoryBase(TContext context)
        {
            _dbContext = context;
        }

        #endregion

        public virtual TEntity Add(TEntity entity, bool autoSave = false)
        {
            DbSet.Add(entity);

            if (autoSave)
            {
                DbContext.SaveChanges();
            }

            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            DbSet.Add(entity);

            if (autoSave)
                await DbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual TEntity Update(TEntity entity, bool autoSave = false)
        {
            DbContext.Entry(entity).State = EntityState.Modified;

            if (autoSave)
            {
                DbContext.SaveChanges();
            }

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            DbContext.Entry(entity).State = EntityState.Modified;

            if (autoSave)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }

            return entity;
        }

        public virtual TEntity Delete(int id, bool autoSave = false)
        {
            var entity = DbSet.Find(id);

            if (entity == null)
                return entity;

            DbSet.Remove(entity);

            if (autoSave)
            {
                DbContext.SaveChanges();
            }

            return entity;
        }

        public virtual async Task<TEntity> DeleteAsync(int id, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity == null)
                return entity;

            DbSet.Remove(entity);

            if (autoSave)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }

            return entity;
        }

        public virtual List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public virtual TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(id, cancellationToken);
        }

        public virtual IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsQueryable();
        }
    }
}
