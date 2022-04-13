using Core.Entities.ValueObjects;

namespace Core.Entities.OrderAggregate
{
    public class OrderItem : Entity<int>
    {
        public ProductItemOrdered? ItemOrdered { get; set; }
        public Price Price { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Price price, int quantity, ProductItemOrdered? itemOrdered = default)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }
        
        protected OrderItem()
        {
            Price = default!;
            Quantity = default!;
        }
        
        
    }
}