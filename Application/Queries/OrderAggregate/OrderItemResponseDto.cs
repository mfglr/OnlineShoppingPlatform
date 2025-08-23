namespace Application.Queries.OrderAggregate
{
    public record OrderItemResponseDto(int ProductId, string Name, decimal Price, int Quantity);
}
