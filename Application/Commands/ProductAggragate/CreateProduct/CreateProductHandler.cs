using Domain.ProductAggregate.Abstracts;
using Domain.ProductAggregate.Entities;
using Domain.ProductAggregate.ValueObjects;
using MediatR;

namespace Application.Commands.ProductAggragate.CreateProduct
{
    internal class CreateProductHandler(IProductRepository productRepository) : IRequestHandler<CreateProductDto>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(CreateProductDto request, CancellationToken cancellationToken)
        {
            var name = new ProductName(request.Name);
            var product = new Product(request.CategoryId, name, request.Price, request.StockQuantity);
            product.Create();
            await _productRepository.CreateAsync(product, cancellationToken);
        }
    }
}
