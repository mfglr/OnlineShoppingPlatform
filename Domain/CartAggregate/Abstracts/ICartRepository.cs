using Core.Abstracts;
using Domain.CartAggregate.Entities;

namespace Domain.CartAggregate.Abstracts
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<List<Cart>> GetCartsByProductId(Guid productId, CancellationToken cancellationToken);
    }
}
