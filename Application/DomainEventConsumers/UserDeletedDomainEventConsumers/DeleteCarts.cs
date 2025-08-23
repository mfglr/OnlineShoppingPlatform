using Core.Events;
using Domain.CartAggregate.Abstracts;
using MediatR;

namespace Application.DomainEventConsumers.UserDeletedDomainEventConsumers
{
    internal class DeleteCarts(ICartRepository cartRepository) : INotificationHandler<UserDeletedEvent>
    {
        private readonly ICartRepository _cartRepository = cartRepository;

        public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByIdAsync(notification.UserId, cancellationToken);
            if (cart == null) return;

            _cartRepository.Delete(cart);
        }
    }
}
