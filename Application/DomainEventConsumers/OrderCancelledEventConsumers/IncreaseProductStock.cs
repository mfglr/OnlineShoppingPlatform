using Core.Events;
using Domain.ProductAggregate.Abstracts;
using MediatR;

namespace Application.DomainEventConsumers.OrderCancelledEventConsumers
{
    internal class IncreaseProductStock(IProductRepository productRepository) : INotificationHandler<OrderCancelledEvent>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(OrderCancelledEvent notification, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByIds(notification.Items.Select(x => x.ProductId), cancellationToken);
            foreach(var item in notification.Items)
            {
                var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                if (product != null)
                    product.IncreaseStockQuantity(item.Quantity);
            }
        }
    }
}
