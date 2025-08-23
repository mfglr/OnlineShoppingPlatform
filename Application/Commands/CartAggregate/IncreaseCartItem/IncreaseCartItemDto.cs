using MediatR;

namespace Application.Commands.CartAggregate.IncreaseCartItem
{
    public record IncreaseCartItemDto(int ProductId) : IRequest;
}
