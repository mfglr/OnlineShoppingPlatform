using Domain.CartAggregate.Abstracts;
using Domain.CartAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CartAggregate
{
    internal class CartRepository(AppDbContext context) : Repository<Cart>(context), ICartRepository
    {
        public override Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => _context.Carts
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public Task<List<Cart>> GetCartsByProductId(Guid productId, CancellationToken cancellationToken)
            => _context.Carts
                .Include(x => x.Items)
                .Where(x => x.Items.Any(x => x.ProductId == productId))
                .ToListAsync(cancellationToken);
    }
}
