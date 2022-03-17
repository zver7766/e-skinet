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

        protected GenericRepository<T> CreateRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(StoreContext);
        }
    }
}