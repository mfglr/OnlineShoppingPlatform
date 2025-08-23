using Application.Exceptions;
using Application.Extentions;
using Core.Events;
using Domain.CartAggregate.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.CartAggregate.ConfirmCart
{
    internal class ConfirmCartHandler(ICartRepository cartRepository, IPublisher publisher, IHttpContextAccessor httpContextAccessor) : IRequestHandler<ConfirmCartDto>
    {
        private readonly ICartRepository _cartRepository = cartRepository;
        private readonly IPublisher _publisher = publisher;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task Handle(ConfirmCartDto request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.GetRequiredUserId();
            var cart = 
                await _cartRepository.GetByIdAsync(userId, cancellationToken) ??
                throw new CartNotFoundException();

            var items = cart.Items.Select(x => new CartConfirmedEvent_CartItem(x.ProductId, x.Quantity)).ToList();
            cart.Clear();

            await _publisher.Publish(new CartConfirmedEvent(userId, items), cancellationToken);
        }
    }
}
