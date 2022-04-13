using System;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // From here tight coupling with integer id!
        IGenericRepository<TEntity, int> Repository<TEntity>()
            where TEntity : class, IEntity<int>;

        Task<int> Complete(); 
    }
}