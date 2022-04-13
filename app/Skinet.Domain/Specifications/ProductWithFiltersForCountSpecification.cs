using Core.Entities.ProductAggregate;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
             : base(x =>
                 (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains
                 (productParams.Search)) &&
                 (!productParams.BrandId.HasValue ||  x.ProductBrand.Id == productParams.BrandId) &&
                 (!productParams.TypeId.HasValue || x.ProductType.Id == productParams.TypeId)
        )
        {
        }

    }
}