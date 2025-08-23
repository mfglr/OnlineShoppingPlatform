using Application.QueryRepositories;
using MediatR;

namespace Application.Queries.ProductAggregate.GetAllProducts
{
    internal class GetAllProductsHandler(IProductQueryRepository productQueryRepository) : IRequestHandler<GetAllProductsDto, List<ProductResponseDto>>
    {
        private readonly IProductQueryRepository _productQueryRepository = productQueryRepository;

        public Task<List<ProductResponseDto>> Handle(GetAllProductsDto request, CancellationToken cancellationToken)
            => _productQueryRepository.GetAllAsync(request, cancellationToken);
    }
}
