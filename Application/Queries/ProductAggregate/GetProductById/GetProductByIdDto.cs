using MediatR;

namespace Application.Queries.ProductAggregate.GetProductById
{
    public record GetProductByIdDto(int Id) : IRequest<ProductResponseDto>;
}
