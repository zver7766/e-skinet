using Core.Entities;
using Core.Entities.ProductAggregate;
using Core.Specifications;

namespace TestProject1.TestSpecifications
{
    public class ProductTypeTestSpecification : BaseSpecification<ProductType>
    {
        public ProductTypeTestSpecification(string name) : base(o => o.Name == name)
        {
            
        }
    }
}