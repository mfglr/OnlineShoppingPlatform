using Domain.CartAggregate.Abstracts;
using Domain.CartAggregate.Entities;
using Domain.CartAggregate.Exceptions;

namespace Domain.CartAggregate.DomainServices
{
    public class CartItemAdder(ICartProductService cartProductService)
    {
        private readonly ICartProductService _cartProductService = cartProductService;

        public async Task AddItem(Cart cart, Guid productId, CancellationToken cancellationToken)
        {
            var stock = await _cartProductService.GetProductStock(productId, cancellationToken);
            
            if (stock < cart.GetItemQuantity(productId) + 1)
                throw new InsufficientStockException();

            cart.AddItem(productId);
        }

        public async Task IncreaseItem(Cart cart, Guid productId, CancellationToken cancellationToken)
        {
            var stock = await _cartProductService.GetProductStock(productId, cancellationToken);
            if (stock < cart.GetItemQuantity(productId) + 1)
                throw new InsufficientStockException();

            cart.IncreaseItem(productId);
        }
    }
}
