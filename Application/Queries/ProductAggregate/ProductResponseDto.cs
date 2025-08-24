namespace Application.Queries.ProductAggregate
{
    public record ProductResponseDto(Guid Id, DateTime CreatedAt, DateTime? UpdatedAt, string Name, decimal Price, int StockQuantity, Guid CategoryId, string CategoryName, int NumberOfLikes);
}
