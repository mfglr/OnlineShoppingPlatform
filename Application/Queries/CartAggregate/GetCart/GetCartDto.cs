using MediatR;

namespace Application.Queries.CartAggregate.GetCart
{
    public record GetCartDto : IRequest<CartResponseDto>;
}
