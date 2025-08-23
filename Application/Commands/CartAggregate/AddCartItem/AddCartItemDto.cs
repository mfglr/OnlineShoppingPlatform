using MediatR;

namespace Application.Commands.CartAggregate.AddCartItem
{
    public record AddCartItemDto(int ProductId) : IRequest;
}
