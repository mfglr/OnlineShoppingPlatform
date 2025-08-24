using Core;

namespace Domain.ProductUserLikeAggregate.Entities
{
    public class ProductUserLike(Guid userId, Guid productId) : Entity, IAggregateRoot
    {
        public Guid UserId { get; private set; } = userId;
        public Guid ProductId { get; private set; } = productId;
    }
}
