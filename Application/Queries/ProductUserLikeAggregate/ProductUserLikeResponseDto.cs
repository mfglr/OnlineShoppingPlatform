namespace Application.Queries.ProductUserLikeAggregate
{
    public record ProductUserLikeResponseDto(Guid Id, Guid ProductId, DateTime CreatedAt, DateTime? UpdatedAt, string Name, decimal Price, int StockQuantity, Guid CategoryId, string CategoryName, int NumberOfLikes);
}
