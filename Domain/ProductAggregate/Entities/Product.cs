using Core;
using Domain.ProductAggregate.Exceptions;
using Domain.ProductAggregate.ValueObjects;

namespace Domain.ProductAggregate.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid CategoryId { get; private set; }
        public ProductName Name { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public byte[] RowVersion { get; private set; } = null!;

        private Product() { }

        public Product(Guid categoryId, ProductName name, decimal price, int stockQuantity)
        {
            if (price <= 0)
                throw new ProductDecimalException();

            if(stockQuantity < 0)
                throw new ProductStockQuantityException();

            CategoryId = categoryId;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public void DecreaseStockQuantity(int quantity)
        {
            if (StockQuantity - quantity < 0)
                throw new ProductStockQuantityException();

            StockQuantity -= quantity;
            UpdatedAt = DateTime.UtcNow;
        }

        public void IncreaseStockQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new IncreaseStockQuantityMustBeGreaterThanZeroException();

            StockQuantity += quantity;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
