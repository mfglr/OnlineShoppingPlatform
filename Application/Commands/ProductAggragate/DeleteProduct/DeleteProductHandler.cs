using Application.Exceptions;
using Domain.ProductAggregate.Abstracts;
using MediatR;

namespace Application.Commands.ProductAggragate.DeleteProduct
{
    internal class DeleteProductHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductDto>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(DeleteProductDto request, CancellationToken cancellationToken)
        {
            var product =
                await _productRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new ProductNotFoundException();
            _productRepository.Delete(product);
        }
    }
}
