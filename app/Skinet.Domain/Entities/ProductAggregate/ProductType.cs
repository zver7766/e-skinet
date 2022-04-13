namespace Core.Entities.ProductAggregate
{
    public class ProductType : Entity<int>
    {
        public string Name { get; }

        public ProductType(string name)
        {
            Name = name;
        }

        protected ProductType()
        {
            Name = default!;
        }
    }
}