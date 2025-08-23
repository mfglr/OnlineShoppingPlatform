using Core;
using Domain.OrderAggregate.Exceptions;
using Domain.OrderAggregate.ValueObjects;

namespace Domain.OrderAggregate.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public int UserId { get; private set; }
        private readonly List<OrderItem> _items = [];
        public IReadOnlyCollection<OrderItem> Items => _items;
        public OrderState State { get; private set; }

        private Order() { }

        public Order(int userId, IEnumerable<OrderItem> orderItems)
        {
            if (!orderItems.Any())
                throw new OrderItemRequiredException();

            UserId = userId;
            _items.AddRange(orderItems);
        }

        public override void Create()
        {
            State = OrderState.Success;
            base.Create();
        }
      
        public void Cancel()
        {
            if (State != OrderState.Success)
                throw new InvalidOrderStateTransitionException();
            State = OrderState.Cancelled;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
