using Application.QueryRepositories;
using MediatR;

namespace Application.Queries.ProductAggregate.GetProductsByCategoryId
{
    internal class GetProductsByCategoryIdHandler(IProductQueryRepository productQueryRepository) : IRequestHandler<GetProductsByCategoryIdDto, List<ProductResponseDto>>
    {
        private readonly IProductQueryRepository _productQueryRepository = productQueryRepository;

        public Task<List<ProductResponseDto>> Handle(GetProductsByCategoryIdDto request, CancellationToken cancellationToken)
            => _productQueryRepository.GetByCategoryId(request.CategoryId,request,cancellationToken);
    }
}
