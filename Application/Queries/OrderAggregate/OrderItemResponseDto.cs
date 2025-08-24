namespace Application.Queries.OrderAggregate
{
    public record OrderItemResponseDto(Guid ProductId, string Name, decimal Price, int Quantity);
}
