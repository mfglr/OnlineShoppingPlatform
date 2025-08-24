using MediatR;

namespace Application.Commands.ProductAggragate.CreateProduct
{
    public record CreateProductDto(Guid CategoryId, string Name, decimal Price, int StockQuantity) : IRequest;
}
