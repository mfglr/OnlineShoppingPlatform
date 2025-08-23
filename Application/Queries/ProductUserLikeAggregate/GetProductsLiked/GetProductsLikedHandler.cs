using Application.Extentions;
using Application.QueryRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Queries.ProductUserLikeAggregate.GetProductsLiked
{
    internal class GetProductsLikedHandler(IProductUserLikeQueryRepository productUserLikeQueryRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetProductsLikedDto, List<ProductUserLikeResponseDto>>
    {
        private readonly IProductUserLikeQueryRepository _productUserLikeQueryRepository = productUserLikeQueryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public Task<List<ProductUserLikeResponseDto>> Handle(GetProductsLikedDto request, CancellationToken cancellationToken)
            => _productUserLikeQueryRepository
                .GetByUserId(_httpContextAccessor.HttpContext.GetRequiredUserId(), request, cancellationToken);
    }
}
