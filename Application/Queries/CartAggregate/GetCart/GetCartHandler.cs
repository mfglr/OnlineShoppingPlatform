using Application.Extentions;
using Application.QueryRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Queries.CartAggregate.GetCart
{
    internal class GetCartHandler(IHttpContextAccessor httpContextAccessor, ICartQueryRepository cartQueryRepository) : IRequestHandler<GetCartDto, CartResponseDto>
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly ICartQueryRepository _cartQueryRepository = cartQueryRepository;

        public async Task<CartResponseDto> Handle(GetCartDto request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.GetRequiredUserId();
            return
                await _cartQueryRepository.GetByIdAsync(userId, cancellationToken) ??
                new CartResponseDto([]);
        }
    }
}
