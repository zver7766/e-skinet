using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.ProductAggregate;
using FluentAssertions;
using TestProject1.Factories;
using TestProject1.TestSpecifications;
using Xunit;

namespace TestProject1.GenericRepositoryTests
{
    public class OperationShould : GenericRepositoryTest
    {
        [Fact]
        public async Task GetProductTypeById_ReturnsProductType_When_ProductTypeExistsValid()
        {
            var productType = ObjectFactory.CreateProductType();
            StoreContext.ProductTypes.Add(productType);
            var repository = CreateRepository<ProductType>();
            
            var result = await repository.GetByIdAsync(productType.Id);
            
            result.Should().Be(productType);
        }
        
        [Fact]
        public async Task GetProductTypeById_ReturnsNull_When_ProductTypeNotExists()
        {
            var notExistentId = 1;
            var repository = CreateRepository<ProductType>();
            
            var result = await repository.GetByIdAsync(notExistentId);
            
            result.Should().BeNull();
        }
        
        [Fact]
        public async Task ListAllProductTypes_ReturnsProductTypesList_WhenProductTypesExists()
        {
            var productTypes = new []
            {
                ObjectFactory.CreateProductType(),
                ObjectFactory.CreateProductType(2, "Test2")
            };

            StoreContext.ProductTypes.AddRange(productTypes);
            await StoreContext.SaveChangesAsync();
            var repository = CreateRepository<ProductType>();
            
            var result = await repository.ListAllAsync();

            result.Count.Should().Be(productTypes.Length);
            result.Should().Contain(productTypes);
        }
        
        [Fact]
        public async Task ListAllProductTypes_ReturnsEmptyList_When_ProductTypeNotExists()
        {
            var repository = CreateRepository<ProductType>();
            
            var result = await repository.ListAllAsync();

            result.Should().BeEmpty();
        }
        
        [Fact]
        public async Task AddProductType_AddingProductType_When_FieldsAreValid()
        {
            var productType = ObjectFactory.CreateProductType();
            var repository = CreateRepository<ProductType>();
            
            repository.Add(productType);
            var result = await repository.GetByIdAsync(productType.Id);
            result.Should().Be(productType);
        }

        [Fact]
        public async Task CountProductType_ReturnsCountOfProductType_WhenProductTypeExists()
        {
            var productType = ObjectFactory.CreateProductType();
            var repository = CreateRepository<ProductType>();
            StoreContext.ProductTypes.Add(productType);
            await StoreContext.SaveChangesAsync();

            var result = await repository.CountAsync(new ProductTypeTestSpecification(productType.Name));
            result.Should().Be(1);
        }

        [Fact]
        public async Task GetEntityBySpecProductType_ReturnsFirstProductTypeWhichSatisfySpecification_WhenProductTypesExists()
        {
            var productType = ObjectFactory.CreateProductType();
            var repository = CreateRepository<ProductType>();
            StoreContext.ProductTypes.Add(productType);
            await StoreContext.SaveChangesAsync();

            var result = await repository.GetEntityWithSpec(new ProductTypeTestSpecification(productType.Name));
            result.Should().Be(productType);
        }
        
        [Fact]
        public async Task ListAsyncProductType_ReturnsProductTypesWhichSatisfySpecification_WhenProductTypesExists()
        {
            var productTypes = new []
            {
                ObjectFactory.CreateProductType(),
                ObjectFactory.CreateProductType(2, "Test2")
            };

            StoreContext.ProductTypes.AddRange(productTypes);
            await StoreContext.SaveChangesAsync();
            var repository = CreateRepository<ProductType>();

            var result = await repository.ListAsync(new ProductTypeTestSpecification(productTypes[0].Name));
            result.Should().NotBeEmpty();
            result[0].Should().Be(productTypes[0]);
        }
    }
}