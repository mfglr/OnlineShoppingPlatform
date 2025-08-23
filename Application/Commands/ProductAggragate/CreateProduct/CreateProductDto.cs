using MediatR;

namespace Application.Commands.ProductAggragate.CreateProduct
{
    public record CreateProductDto(int CategoryId, string Name, decimal Price, int StockQuantity) : IRequest;
}
