using System;
using System.Linq.Expressions;
using Core.Entities.OrderAggregate;

namespace Core.Spesifications
{
    public class OrderWithItemsAndOrderingSpecification : BaseSpesification<Order>
    {
        public OrderWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
        {
            AddIncule(o => o.OrderItems);
            AddIncule(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrderWithItemsAndOrderingSpecification(int id, string email)
            : base(o => o.Id == id && o.BuyerEmail == email)
        {
            AddIncule(o => o.OrderItems);
            AddIncule(o => o.DeliveryMethod);
        }
    }
}