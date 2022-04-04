using Core.Entities;

namespace TestProject1.Factories
{
    public static class ObjectFactory
    {
        public static ProductType CreateProductType(int id = 1, string name = "Test1")
        {
            return new ProductType
            {
                Id = id,
                Name = name
            };
        }
    
    }
}