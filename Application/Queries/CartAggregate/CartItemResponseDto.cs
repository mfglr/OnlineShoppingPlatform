namespace Application.Queries.CartAggregate
{
    public record CartItemResponseDto(int ProductId, string ProductName, decimal Price, int Quantity);
}
