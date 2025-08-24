using Core.Abstracts;
using Domain.ProductAggregate.Entities;

namespace Domain.ProductAggregate.Abstracts
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProductsByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken);
        Task<List<Product>> GetProductsByCategoryId(Guid categoryId, CancellationToken cancellationToken);
    }
}
