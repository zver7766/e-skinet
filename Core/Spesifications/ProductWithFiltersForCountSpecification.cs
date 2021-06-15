using Core.Entities;

namespace Core.Spesifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpesification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
             : base(x =>
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
        {
            
        }

    }
}