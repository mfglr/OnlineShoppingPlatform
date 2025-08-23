using Application.Extentions;
using Domain.ProductUserLikeAggregate.Abstracts;
using Domain.ProductUserLikeAggregate.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.ProductUserLikeAggregate.DislikeProduct
{
    internal class DislikeProductHandler(IProductUserLikeRepository productUserLikeRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<DislikeDto>
    {
        private readonly IProductUserLikeRepository _productUserLikeRepository = productUserLikeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task Handle(DislikeDto request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.GetRequiredUserId();
            var like =
                await _productUserLikeRepository.GetAsync(userId, request.ProductId, cancellationToken) ??
                throw new ProductAlreadyDislikedException();
            _productUserLikeRepository.Delete(like);
        }
    }
}
