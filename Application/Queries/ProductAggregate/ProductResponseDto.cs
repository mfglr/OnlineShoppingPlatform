namespace Application.Queries.ProductAggregate
{
    public record ProductResponseDto(int Id, DateTime CreatedAt, DateTime? UpdatedAt, string Name, decimal Price, int StockQuantity, int CategoryId, string CategoryName, int NumberOfLikes);
}
