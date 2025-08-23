namespace Domain.CartAggregate.Abstracts
{
    public interface ICartProductService
    {
        Task<int> GetProductStock(int productId, CancellationToken cancellationToken);
    }
}
