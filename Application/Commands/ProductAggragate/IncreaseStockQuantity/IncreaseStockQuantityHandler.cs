using Application.Exceptions;
using Domain.ProductAggregate.Abstracts;
using MediatR;

namespace Application.Commands.ProductAggragate.IncreaseStockQuantity
{
    internal class IncreaseStockQuantityHandler(IProductRepository productRepository) : IRequestHandler<IncreaseStockQuantityDto>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(IncreaseStockQuantityDto request, CancellationToken cancellationToken)
        {
            var product =
                await _productRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ProductNotFoundException();
            product.IncreaseStockQuantity(request.StockQuantity);
        }
    }
}
