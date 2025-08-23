using Application.QueryRepositories;
using MediatR;

namespace Application.Queries.ProductAggregate.SearchProducts
{
    internal class SearchProductsHandler(IProductQueryRepository productQueryRepository) : IRequestHandler<SearchProductsDto, List<ProductResponseDto>>
    {
        private readonly IProductQueryRepository _productQueryRepository = productQueryRepository;

        public Task<List<ProductResponseDto>> Handle(SearchProductsDto request, CancellationToken cancellationToken)
            => _productQueryRepository.SearchAsync(request.Key, request, cancellationToken);
    }
}
