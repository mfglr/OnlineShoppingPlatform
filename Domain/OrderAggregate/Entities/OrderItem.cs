using Core;
using Domain.OrderAggregate.Exceptions;

namespace Domain.OrderAggregate.Entities
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(Guid productId, string name, decimal price, int quantity)
        {
            if (quantity <= 0)
                throw new OrderItemQuantityException();

            ProductId = productId;
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }
}
