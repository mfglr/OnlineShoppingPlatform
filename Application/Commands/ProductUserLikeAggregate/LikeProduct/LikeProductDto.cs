using MediatR;

namespace Application.Commands.ProductUserLikeAggregate.LikeProduct
{
    public record LikeProductDto(Guid ProductId) : IRequest;
}
