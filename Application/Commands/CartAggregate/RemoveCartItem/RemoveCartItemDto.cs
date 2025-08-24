using MediatR;

namespace Application.Commands.CartAggregate.RemoveCartItem
{
    public record RemoveCartItemDto(Guid ProductId) : IRequest;
}
