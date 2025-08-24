namespace Application.Queries.CartAggregate
{
    public record CartItemResponseDto(Guid ProductId, string ProductName, decimal Price, int Quantity);
}
