using MediatR;

namespace Application.Commands.CartAggregate.RemoveCartItem
{
    public record RemoveCartItemDto(int ProductId) : IRequest;
}
