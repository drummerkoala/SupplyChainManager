using SupplyChainManager.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SupplyChainManager.Shared.Abstractions.Persistence
{
    public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        Task<TEntity?> GetByIdAsync(TId id);

        Task<List<TEntity>> ListAsync();

        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }

    // default is Guid
    public interface IRepository<TEntity> : IRepository<TEntity, Guid>
        where TEntity : class, IEntity
    {
    }
}
