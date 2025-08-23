using Core.Events;
using Domain.ProductAggregate.Abstracts;
using Domain.ProductAggregate.Entities;
using MediatR;

namespace Application.DomainEventConsumers.CartConfirmedEventConsumers
{
    internal class DecreaseProductStock(IProductRepository productRepository, IPublisher publisher) : INotificationHandler<CartConfirmedEvent>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IPublisher _publisher = publisher;

        private static bool HasStock(IEnumerable<CartConfirmedEvent_CartItem> items, IEnumerable<Product> products)
            => items.All(item => products.Any(product => product.StockQuantity >= item.Quantity && product.Id == item.ProductId));

        public async Task Handle(CartConfirmedEvent notification, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByIds(notification.Items.Select(x => x.ProductId), cancellationToken);

            if(!HasStock(notification.Items, products))
            {
                List<DecreaseProductsStockFailedEvent_Item> newFailedItems = [];
                foreach (var item in notification.Items)
                {
                    var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                    if (product != null && product.StockQuantity > 0)
                        newFailedItems.Add(
                            new(
                                item.ProductId,
                                item.Quantity <= product.StockQuantity ? item.Quantity : product.StockQuantity
                            )
                        );
                }
                await _publisher.Publish(
                    new DecreaseProductsStockFailedEvent(notification.UserId, newFailedItems),
                    cancellationToken
                );
            }
            else
            {
                List<DecreaseProductsStockSuccessEvent_Item> newSuccessItems = [];
                foreach (var item in notification.Items)
                {
                    var product = products.First(x => x.Id == item.ProductId);
                    product.DecreaseStockQuantity(item.Quantity);
                    newSuccessItems.Add(new(product.Id, product.Name.Value, product.Price, item.Quantity));
                }
                await _publisher.Publish(
                    new DecreaseProductsStockSuccessEvent(notification.UserId, newSuccessItems),
                    cancellationToken
                );
            }
        }
    }
}
