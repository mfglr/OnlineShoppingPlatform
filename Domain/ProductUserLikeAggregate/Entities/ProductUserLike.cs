using Core;

namespace Domain.ProductUserLikeAggregate.Entities
{
    public class ProductUserLike(int userId, int productId) : Entity, IAggregateRoot
    {
        public int UserId { get; private set; } = userId;
        public int ProductId { get; private set; } = productId;
    }
}
