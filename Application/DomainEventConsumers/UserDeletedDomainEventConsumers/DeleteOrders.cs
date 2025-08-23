using Core.Events;
using Domain.OrderAggregate.Abstracts;
using MediatR;

namespace Application.DomainEventConsumers.UserDeletedDomainEventConsumers
{
    internal class DeleteOrders(IOrderRepository orderRepository) : INotificationHandler<UserDeletedEvent>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByUserId(notification.UserId, cancellationToken);
            _orderRepository.DeleteRange(orders);
        }
    }
}
