using Core.Events;
using Domain.OrderAggregate.Abstracts;
using Domain.OrderAggregate.Entities;
using MediatR;

namespace Application.DomainEventConsumers.DecreaseProductsStockSuccessEventConsumers
{
    internal class CreateOrder(IOrderRepository orderRepository) : INotificationHandler<DecreaseProductsStockSuccessEvent>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task Handle(DecreaseProductsStockSuccessEvent notification, CancellationToken cancellationToken)
        {
            var orderItems = notification.Items.Select(x => new OrderItem(x.ProductId, x.Name, x.Price, x.Quantity));
            var order = new Order(notification.UserId, orderItems);
            order.Create();
            await _orderRepository.CreateAsync(order,cancellationToken);
        }
    }
}
