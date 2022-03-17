using System.Threading.Tasks;
using Core.Entities;
using FluentAssertions;
using Xunit;

namespace TestProject1.GenericRepositoryTests
{
    public class OperationShould : GenericRepositoryTest
    {
        [Fact]
        public async Task GetById_Ok_WhenAllValid()
        {
            var productType = new ProductType()
            {
                Id = 1,
                Name = "Test1"
            };
            StoreContext.ProductTypes.Add(productType);
            var repository = CreateRepository<ProductType>();
            
            var result = await repository.GetByIdAsync(productType.Id);
            
            result.Should().Be(productType);
        }
        
        [Fact]
        public async Task GetById_Ok_WhenNotExists()
        {
            var notExistentId = 1;
            var repository = CreateRepository<ProductType>();
            
            var result = await repository.GetByIdAsync(notExistentId);
            
            result.Should().BeNull();
        }
        
        [Fact]
        public async Task ListAll_Ok_WhenAllValid()
        {
            var productType = new ProductType()
            {
                Id = 1,
                Name = "Test1"
            };
            StoreContext.ProductTypes.Add(productType);
            StoreContext.SaveChanges();
            var repository = CreateRepository<ProductType>();
            
            var result = await repository.ListAllAsync();

            result.Count.Should().Be(1);
            result.Should().Contain(productType);
        }
        
        [Fact]
        public async Task ListAll_EmptyOk_WhenNoRowsInDb()
        {
            var repository = CreateRepository<ProductType>();
            
            var result = await repository.ListAllAsync();

            result.Should().BeEmpty();
        }
        
        [Fact]
        public async Task Add_Ok_WhenAllValid()
        {
            var productType = new ProductType()
            {
                Id = 1,
                Name = "Test1"
            };
            var repository = CreateRepository<ProductType>();
            
            repository.Add(productType);
            var result = await repository.GetByIdAsync(productType.Id);
            result.Should().Be(productType);
        }
    }
}