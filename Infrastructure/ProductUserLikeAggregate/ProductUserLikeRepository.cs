using Domain.ProductUserLikeAggregate.Abstracts;
using Domain.ProductUserLikeAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ProductUserLikeAggregate
{
    internal class ProductUserLikeRepository(AppDbContext context) : Repository<ProductUserLike>(context), IProductUserLikeRepository
    {
        public Task<bool> ExistAsync(Guid userId, Guid productId, CancellationToken cancellationToken)
            => _context.ProductUserLikes.AnyAsync(x => x.UserId == userId && x.ProductId == productId,cancellationToken);

        public Task<ProductUserLike?> GetAsync(Guid userId, Guid productId, CancellationToken cancellationToken)
            => _context.ProductUserLikes.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId,cancellationToken);
    }
}
