using MediatR;

namespace Application.Commands.ProductUserLikeAggregate.DislikeProduct
{
    public record DislikeDto(Guid ProductId) : IRequest;
}
