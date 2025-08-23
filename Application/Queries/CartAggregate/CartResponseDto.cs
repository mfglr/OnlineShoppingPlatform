namespace Application.Queries.CartAggregate
{
    public record CartResponseDto(IEnumerable<CartItemResponseDto> Items);
}
