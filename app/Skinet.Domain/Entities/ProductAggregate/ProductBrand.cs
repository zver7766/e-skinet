namespace Core.Entities.ProductAggregate
{
    public class ProductBrand : Entity<int>
    {
        public string Name { get; }

        public ProductBrand(string name)
        {
            Name = name;
        }

        protected ProductBrand()
        {
            Name = default!;
        }
    }
}