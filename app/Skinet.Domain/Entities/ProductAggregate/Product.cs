using Core.Entities.ValueObjects;

namespace Core.Entities.ProductAggregate
{
    public class Product : Entity<int>
    {
        public string Name { get; }
        public string Description { get; }
        public Price Price { get; }
        public string PictureUrl { get; }
        public ProductType ProductType { get; }
        public ProductBrand ProductBrand { get; }

        public Product(string name, string description, Price price, string pictureUrl, ProductType productType, ProductBrand productBrand)
        {
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            ProductType = productType;
            ProductBrand = productBrand;
        }

        protected Product()
        {
            Name = default!;
            Description = default!;
            Price = default!;
            PictureUrl = default!;
            ProductType = default!;
            ProductBrand = default!;
        }
        
        
    }
}