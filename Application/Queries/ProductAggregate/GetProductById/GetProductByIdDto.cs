using MediatR;

namespace Application.Queries.ProductAggregate.GetProductById
{
    public record GetProductByIdDto(Guid Id) : IRequest<ProductResponseDto>;
}
