using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<TEntity, TEntityId>
        where TEntity : class, IEntity<TEntityId> 
        where TEntityId : IComparable, IEquatable<TEntityId>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spec);
        Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec);
        Task<int> CountAsync(ISpecification<TEntity> spec);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}