using MediatR;

namespace Application.Commands.CartAggregate.DecreaseCartItem
{
    public record DecreaseCartItemDto(Guid ProductId) : IRequest;
}
