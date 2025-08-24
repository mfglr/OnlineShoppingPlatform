using Application.Queries.ProductUserLikeAggregate;
using Application.QueryRepositories;
using Core;
using Domain.ProductUserLikeAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryRepositories
{
    internal static class ProductUserLikeQueryableMapper
    {
        public static IQueryable<ProductUserLikeResponseDto> ToProductUserLikeResponseDto(this IQueryable<ProductUserLike> query, AppDbContext context)
            => query
                .Join(
                    context.Products,
                    pul => pul.ProductId,
                    product => product.Id,
                    (pul, product) => new { pul, product }
                )
                .Join(
                    context.Categories,
                    join => join.product.CategoryId,
                    category => category.Id,
                    (join, category) => new ProductUserLikeResponseDto(
                            join.pul.Id,
                            join.pul.ProductId,
                            join.product.CreatedAt,
                            join.product.UpdatedAt,
                            join.product.Name.Value,
                            join.product.Price,
                            join.product.StockQuantity,
                            join.product.CategoryId,
                            category.Name.Value,
                            context.ProductUserLikes.Count(x => x.ProductId == join.product.Id)
                        )
                );
    }

    internal class ProductUserLikeQueryRepository(AppDbContext context) : IProductUserLikeQueryRepository
    {
        private readonly AppDbContext _context = context;

        public Task<List<ProductUserLikeResponseDto>> GetByUserId(Guid userId, Page page, CancellationToken cancellationToken)
            => _context.ProductUserLikes
                .Where(x => x.UserId == userId)
                .ToPage(page)
                .ToProductUserLikeResponseDto(_context)
                .ToListAsync(cancellationToken);
    }
}
