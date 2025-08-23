using Application.Extentions;
using Domain.ProductUserLikeAggregate.Abstracts;
using Domain.ProductUserLikeAggregate.Entities;
using Domain.ProductUserLikeAggregate.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.ProductUserLikeAggregate.LikeProduct
{
    internal class LikeProductHandler(IProductUserLikeRepository productUserLikeRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<LikeProductDto>
    {
        private readonly IProductUserLikeRepository _productUserLikeRepository = productUserLikeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task Handle(LikeProductDto request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.GetRequiredUserId();
            if (await _productUserLikeRepository.ExistAsync(userId, request.ProductId, cancellationToken))
                throw new ProductAlreadyLikedException();

            var like = new ProductUserLike(userId, request.ProductId);
            like.Create();
            await _productUserLikeRepository.CreateAsync(like, cancellationToken);
        }
    }
}
