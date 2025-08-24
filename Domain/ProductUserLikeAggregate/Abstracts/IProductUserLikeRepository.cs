using Core.Abstracts;
using Domain.ProductUserLikeAggregate.Entities;

namespace Domain.ProductUserLikeAggregate.Abstracts
{
    public interface IProductUserLikeRepository : IRepository<ProductUserLike>
    {
        Task<bool> ExistAsync(Guid userId, Guid productId, CancellationToken cancellationToken);
        Task<ProductUserLike?> GetAsync(Guid userId, Guid productId, CancellationToken cancellationToken);
    }
}
