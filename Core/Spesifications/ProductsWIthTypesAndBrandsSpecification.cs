using Core.Entities;

namespace Core.Spesifications
{
    public class ProductsWIthTypesAndBrandsSpecification : BaseSpesification<Product>
    {

        public ProductsWIthTypesAndBrandsSpecification(string sort, int? brandId, int? typeId)
            : base(x => 
                (!brandId.HasValue || x.ProductBrandId == brandId) && 
                (!typeId.HasValue || x.ProductTypeId == typeId)
            )
        {
            AddIncule(x => x.ProductType);
            AddIncule(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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