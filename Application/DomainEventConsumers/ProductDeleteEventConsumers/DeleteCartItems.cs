using Core.Events;
using Domain.CartAggregate.Abstracts;
using MediatR;

namespace Application.DomainEventConsumers.ProductDeleteEventConsumers
{
    internal class DeleteCartItems(ICartRepository cartRepository) : INotificationHandler<ProductDeletedEvent>
    {
        private readonly ICartRepository _cartRepository = cartRepository;

        public async Task Handle(ProductDeletedEvent notification, CancellationToken cancellationToken)
        {
            var carts = await _cartRepository.GetCartsByProductId(notification.ProductId, cancellationToken);
            foreach (var cart in carts)
                cart.RemoveItem(notification.ProductId);
        }
    }
}
