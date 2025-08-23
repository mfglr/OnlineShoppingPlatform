using Domain.OrderAggregate.ValueObjects;

namespace Application.Queries.OrderAggregate
{
    public record OrderResponseDto(int Id, IEnumerable<OrderItemResponseDto> Items, OrderState State);
}
