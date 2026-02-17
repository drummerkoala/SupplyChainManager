using SupplyChainManager.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;

namespace SupplyChainManager.Shared.Abstractions.Persistence
{
    public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        Task<TEntity?> GetByIdAsync(TId id, bool asNoTracking = true, CancellationToken cancellationToken = default);

        Task<IEnumerable<TResult>> ListAsync<TResult>(
            Expression<Func<TEntity, TResult>>? selector = null,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool asNoTracking = true,
            CancellationToken cancellationToken = default);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }

    // default is Guid
    public interface IRepository<TEntity> : IRepository<TEntity, Guid>
        where TEntity : class, IEntity
    {
    }
}
