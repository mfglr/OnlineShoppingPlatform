using Domain.ProductAggregate.Abstracts;
using Domain.ProductAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ProductAggregate
{
    internal class ProductRepository(AppDbContext context) : Repository<Product>(context), IProductRepository
    {
        public Task<List<Product>> GetProductsByCategoryId(int categoryId, CancellationToken cancellationToken)
            => _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync(cancellationToken);

        public Task<List<Product>> GetProductsByIds(IEnumerable<int> ids, CancellationToken cancellationToken)
            => _context.Products.Where(x => ids.Any(id => id == x.Id)).ToListAsync(cancellationToken);
    }
}
