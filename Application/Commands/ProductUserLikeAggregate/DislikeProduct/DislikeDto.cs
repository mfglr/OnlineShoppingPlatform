using MediatR;

namespace Application.Commands.ProductUserLikeAggregate.DislikeProduct
{
    public record DislikeDto(int ProductId) : IRequest;
}
