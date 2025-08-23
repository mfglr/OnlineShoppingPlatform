namespace Application.Queries.ProductUserLikeAggregate
{
    public record ProductUserLikeResponseDto(int Id, int ProductId, DateTime CreatedAt, DateTime? UpdatedAt, string Name, decimal Price, int StockQuantity, int CategoryId, string CategoryName, int NumberOfLikes);
}
