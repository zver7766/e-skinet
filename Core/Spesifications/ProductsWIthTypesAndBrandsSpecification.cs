using Core.Entities;

namespace Core.Spesifications
{
    public class ProductsWIthTypesAndBrandsSpecification : BaseSpesification<Product>
    {

        public ProductsWIthTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(x => 
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) && 
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            AddIncule(x => x.ProductType);
            AddIncule(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
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
            AddIncule(x => x.ProductType);
            AddIncule(x => x.ProductBrand);
        }
    }
}