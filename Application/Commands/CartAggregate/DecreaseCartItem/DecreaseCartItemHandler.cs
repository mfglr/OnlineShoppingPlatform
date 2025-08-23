using Application.Extentions;
using Domain.CartAggregate.Abstracts;
using Domain.CartAggregate.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.CartAggregate.DecreaseCartItem
{
    internal class DecreaseCartItemHandler(ICartRepository cartRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<DecreaseCartItemDto>
    {
        private readonly ICartRepository _cartRepository = cartRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task Handle(DecreaseCartItemDto request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.GetRequiredUserId();
            var cart = await _cartRepository.GetByIdAsync(userId, cancellationToken);
            if(cart == null)
            {
                cart = new Cart(userId);
                cart.Create();
                await _cartRepository.CreateAsync(cart, cancellationToken);
            }
            cart.DecreaseItem(request.ProductId);
        }
    }
}
