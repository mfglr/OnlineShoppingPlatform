using Domain.OrderAggregate.ValueObjects;

namespace Application.Queries.OrderAggregate
{
    public record OrderResponseDto(Guid Id, IEnumerable<OrderItemResponseDto> Items, OrderState State);
}
