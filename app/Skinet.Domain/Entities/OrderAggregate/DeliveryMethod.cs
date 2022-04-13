using Core.Entities.ValueObjects;

namespace Core.Entities.OrderAggregate
{
    public class DeliveryMethod : Entity<int>
    {
        public string? ShortName { get; private set; }
        public string? DeliveryTime { get; private set; }
        public string? Description { get; private set; }
        public Price Price { get; private set; }

        public DeliveryMethod(Price price, string? shortName = default, string? deliveryTime = default, string? description = default)
        {
            ShortName = shortName;
            DeliveryTime = deliveryTime;
            Description = description;
            Price = price;
        }

        protected DeliveryMethod()
        {
            Price = default!;
        }
        
        
    }
}