using MediatR;

namespace Application.Commands.ProductAggragate.DeleteProduct
{
    public record DeleteProductDto(Guid Id) : IRequest;
}
