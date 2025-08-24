using Core;
using Domain.CartAggregate.Exceptions;

namespace Domain.CartAggregate.Entities
{
    public class Cart : Entity, IAggregateRoot
    {
        private readonly List<CartItem> _items = [];
        public IReadOnlyList<CartItem> Items => _items;

        private Cart() { }

        public Cart(Guid userId) => Id = userId;

        public bool IsEmpty() => _items.Count == 0;
        public int GetItemQuantity(Guid productId) => _items.FirstOrDefault(x => x.ProductId == productId)?.Quantity ?? 0;

        public void Clear()
        {
            _items.Clear();
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddItems(IEnumerable<CartItem> items)
        {
            _items.AddRange(items);
            UpdatedAt = DateTime.UtcNow;
        }

        internal void AddItem(Guid productId)
        {
            var cartItem = _items.FirstOrDefault(x => x.ProductId == productId);
            if(cartItem != null)
                cartItem.IncreaseQuantity();
            else
            {
                var item = CartItem.Create(productId);
                item.Create();
                _items.Add(item);
            }

            UpdatedAt = DateTime.UtcNow;
        }
        public void RemoveItem(Guid productId)
        {
            var item =
                _items.FirstOrDefault(x => x.ProductId == productId) ??
                throw new CartItemNotFoundException();

            _items.Remove(item);
            UpdatedAt = DateTime.UtcNow;
        }
        internal void IncreaseItem(Guid productId)
        {
            var item =
                _items.FirstOrDefault(x => x.ProductId == productId) ??
                throw new CartItemNotFoundException();
            item.IncreaseQuantity();
            
            UpdatedAt = DateTime.UtcNow;
        }
        public void DecreaseItem(Guid productId)
        {
            var item =
                _items.FirstOrDefault(x => x.ProductId == productId) ??
                throw new CartItemNotFoundException();

            if (item.Quantity <= 1)
                _items.Remove(item);
            else
                item.DecreaseQuantity();

            UpdatedAt = DateTime.UtcNow;
        }
    }
}
