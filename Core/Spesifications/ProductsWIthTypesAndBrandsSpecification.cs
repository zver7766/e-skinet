using Core.Entities;

namespace Core.Spesifications
{
    public class ProductsWIthTypesAndBrandsSpecification : BaseSpesification<Product>
    {
        public ProductsWIthTypesAndBrandsSpecification()
        {
            AddIncule(x => x.ProductType);
            AddIncule(x => x.ProductBrand);
        }

        public ProductsWIthTypesAndBrandsSpecification(int id)
            : base(x => x.Id == id)
        {
            AddIncule(x => x.ProductType);
            AddIncule(x => x.ProductBrand);
        }
    }
}