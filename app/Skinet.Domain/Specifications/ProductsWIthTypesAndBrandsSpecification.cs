using Core.Entities.ProductAggregate;

namespace Core.Specifications
{
    public class ProductsWIthTypesAndBrandsSpecification : BaseSpecification<Product>
    {

        public ProductsWIthTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains
                (productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrand.Id == productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductType.Id == productParams.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price.Value);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price.Value);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWIthTypesAndBrandsSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}