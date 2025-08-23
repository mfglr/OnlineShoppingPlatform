using MediatR;

namespace Application.Commands.ProductAggragate.DeleteProduct
{
    public record DeleteProductDto(int Id) : IRequest;
}
