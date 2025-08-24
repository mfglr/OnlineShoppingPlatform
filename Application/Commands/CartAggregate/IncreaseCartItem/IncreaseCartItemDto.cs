using MediatR;

namespace Application.Commands.CartAggregate.IncreaseCartItem
{
    public record IncreaseCartItemDto(Guid ProductId) : IRequest;
}
