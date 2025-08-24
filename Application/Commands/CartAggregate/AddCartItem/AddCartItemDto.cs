using MediatR;

namespace Application.Commands.CartAggregate.AddCartItem
{
    public record AddCartItemDto(Guid ProductId) : IRequest;
}
