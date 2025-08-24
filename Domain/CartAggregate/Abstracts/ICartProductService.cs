namespace Domain.CartAggregate.Abstracts
{
    public interface ICartProductService
    {
        Task<int> GetProductStock(Guid productId, CancellationToken cancellationToken);
    }
}
