using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SupplyChainManager.Shared.Abstractions.Domain;
using SupplyChainManager.Shared.Abstractions.Persistence;
using System.Linq.Expressions;

namespace SupplyChainManager.Shared.Persistence
{
    public class Repository<TEntity, TId> : 
        IRepository<TEntity, TId> where TEntity : class,
        IEntity<TId>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;


        public Repository(
            DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TId id, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<TResult>> ListAsync<TResult>(
            Expression<Func<TEntity, TResult>>? selector = null,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool asNoTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (selector == null)
            {
                return await (query as IQueryable<TResult>)!.ToListAsync(cancellationToken).ConfigureAwait(false);
            }

            return await query.Select(selector).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            if (entity is ICreateAuditable creationEntity)
            {
                creationEntity.CreatedAt = now;
                creationEntity.CreatedBy = "SYSTEM";
            }

            await _dbSet.AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);
            await _dbContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            if (entity is IUpdateAuditable modificationEntity)
            {
                modificationEntity.UpdatedAt = now;
                modificationEntity.UpdatedBy = "SYSTEM";
            }

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity is ISoftDeletable softDeleteEntity)
            {
                var now = DateTime.UtcNow;

                softDeleteEntity.IsDeleted = true;
                softDeleteEntity.DeletedAt = now;
                softDeleteEntity.DeletedBy = "SYSTEM";

                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _dbSet.Remove(entity);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
