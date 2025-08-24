using Application.Queries.CartAggregate;
using Application.QueryRepositories;
using Domain.CartAggregate.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryRepositories
{
    internal static class CartQueryableMappers
    {
        public static IQueryable<CartResponseDto> ToCartResponseDto(this IQueryable<Cart> query, AppDbContext context)
            => query
                .Select(
                    x => new CartResponseDto(
                        x.Items.Join(
                            context.Products,
                            item => item.ProductId,
                            product => product.Id,
                            (item, product) => new CartItemResponseDto(
                                product.Id,
                                product.Name.Value,
                                product.Price,
                                item.Quantity
                            )
                        )
                    )
                );
    }

    internal class CartQueryRepository(AppDbContext context) : ICartQueryRepository
    {
        private readonly AppDbContext _context = context;

        public Task<CartResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => _context.Carts
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToCartResponseDto(_context)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
