using Core.Abstracts;
using Domain.ProductUserLikeAggregate.Entities;

namespace Domain.ProductUserLikeAggregate.Abstracts
{
    public interface IProductUserLikeRepository : IRepository<ProductUserLike>
    {
        Task<bool> ExistAsync(int userId, int productId, CancellationToken cancellationToken);
        Task<ProductUserLike?> GetAsync(int userId, int productId, CancellationToken cancellationToken);
    }
}
