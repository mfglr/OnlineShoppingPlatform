using MediatR;

namespace Application.Commands.ProductUserLikeAggregate.LikeProduct
{
    public record LikeProductDto(int ProductId) : IRequest;
}
