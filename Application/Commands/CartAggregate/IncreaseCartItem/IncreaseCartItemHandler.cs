using Application.Extentions;
using Domain.CartAggregate.Abstracts;
using Domain.CartAggregate.DomainServices;
using Domain.CartAggregate.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.CartAggregate.IncreaseCartItem
{
    internal class IncreaseCartItemHandler(ICartRepository cartRepository, IHttpContextAccessor httpContextAccessor, CartItemAdder cartItemAdder) : IRequestHandler<IncreaseCartItemDto>
    {
        private readonly ICartRepository _cartRepository = cartRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly CartItemAdder _cartItemAdder = cartItemAdder;

        public async Task Handle(IncreaseCartItemDto request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.GetRequiredUserId();
            var cart = await _cartRepository.GetByIdAsync(userId, cancellationToken);
            if (cart == null)
            {
                cart = new Cart(userId);
                cart.Create();
                await _cartRepository.CreateAsync(cart, cancellationToken);
            }
            await _cartItemAdder.IncreaseItem(cart, request.ProductId,cancellationToken);
        }
    }
}
