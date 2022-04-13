using System;
using System.Collections.Generic;
using Core.Entities.Enums;
using Core.Entities.ValueObjects;

namespace Core.Entities.OrderAggregate
{
    public class Order : Entity<int>
    {
        public Email? BuyerEmail { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address? ShipToAddress { get; private set; }
        public DeliveryMethod? DeliveryMethod { get; private set; }
        public IReadOnlyList<OrderItem> OrderItems { get; private set; }
        public Price Subtotal { get; private set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        
        public string? PaymentIntentId { get; private set; }

        public Order(IReadOnlyList<OrderItem> orderItems,
            Price subtotal,
            Email? buyerEmail = default,
            Address? shipToAddress = default,
            DeliveryMethod? deliveryMethod = default)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
        }
        
        protected Order()
        {
            OrderItems = default!;
            Subtotal = default!;
        }

        public decimal GetTotal()
        {
            return Subtotal.Value + DeliveryMethod.Price;
        }
    }
}