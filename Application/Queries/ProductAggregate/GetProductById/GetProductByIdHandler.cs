using Application.QueryRepositories;
using MediatR;
using Application.Exceptions;

namespace Application.Queries.ProductAggregate.GetProductById
{
    internal class GetProductByIdHandler(IProductQueryRepository productQueryRepository) : IRequestHandler<GetProductByIdDto, ProductResponseDto>
    {
        private readonly IProductQueryRepository _productQueryRepository = productQueryRepository;

        public async Task<ProductResponseDto> Handle(GetProductByIdDto request, CancellationToken cancellationToken)
            =>
                await _productQueryRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ProductNotFoundException();
    }
}
