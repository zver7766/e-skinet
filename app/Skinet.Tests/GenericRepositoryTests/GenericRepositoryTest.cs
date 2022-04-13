using System;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TestProject1.GenericRepositoryTests
{
    public class GenericRepositoryTest
    {
        protected readonly StoreContext StoreContext;

        public GenericRepositoryTest()
        {
            var options = new DbContextOptionsBuilder();
            options.UseInMemoryDatabase(Guid.NewGuid().ToString());
            StoreContext = new StoreContext(options);
        }

        protected GenericRepository<TEntity> CreateRepository<TEntity>()
            where TEntity : class, IEntity<int>
        {
            return new GenericRepository<TEntity>(StoreContext);
        }
    }
}