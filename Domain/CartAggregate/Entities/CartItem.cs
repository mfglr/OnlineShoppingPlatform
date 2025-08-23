using Core;
using Domain.CartAggregate.Exceptions;

namespace Domain.CartAggregate.Entities
{
    public class CartItem : Entity
    {
        public int CartId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        public CartItem(int productId, int quantity)
        {
            if (quantity < 1)
                throw new CartItemQuantityException();

            ProductId = productId;
            Quantity = quantity;
        }


        internal static CartItem Create(int productId) => new(productId, 1) { CreatedAt = DateTime.UtcNow };
        public void IncreaseQuantity()
        {
            Quantity++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void DecreaseQuantity()
        {
            if(Quantity < 1)
                throw new CartItemQuantityException();
            Quantity--;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
