using Core.Entities.ProductAggregate;

namespace TestProject1.Factories
{
    public static class ObjectFactory
    {
        public static ProductType CreateProductType(int id = 1, string name = "Test1")
        {
            return new ProductType(name);
        }
    
    }
}