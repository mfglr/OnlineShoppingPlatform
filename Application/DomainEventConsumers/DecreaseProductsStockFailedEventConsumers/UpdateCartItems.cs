using Core.Events;
using Domain.CartAggregate.Abstracts;
using Domain.CartAggregate.Entities;
using MediatR;

namespace Application.DomainEventConsumers.DecreaseProductsStockFailedEventConsumers
{
    internal class UpdateCartItems(ICartRepository cartRepository) : INotificationHandler<DecreaseProductsStockFailedEvent>
    {
        private readonly ICartRepository _cartRepository = cartRepository;

        public async Task Handle(DecreaseProductsStockFailedEvent notification, CancellationToken cancellationToken)
        {
            var cart = (await _cartRepository.GetByIdAsync(notification.UserId, cancellationToken))!;
            cart.AddItems(notification.Items.Select(x => new CartItem(x.ProductId, x.Quantity)));
        }
    }
}
