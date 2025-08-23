using MediatR;

namespace Application.Commands.CartAggregate.DecreaseCartItem
{
    public record DecreaseCartItemDto(int ProductId) : IRequest;
}
