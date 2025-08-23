using Application.Queries.ProductAggregate;
using Application.QueryRepositories;
using Azure;
using Core;
using Domain.ProductAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.Threading;

namespace Infrastructure.QueryRepositories
{

    internal static class ProductQueryableMappers
    {
        public static IQueryable<ProductResponseDto> ToProductResponseDto(this IQueryable<Product> products, AppDbContext context)
            => products
                .Join(
                    context.Categories,
                    product => product.CategoryId,
                    category => category.Id,
                    (product, category) => new ProductResponseDto(
                            product.Id,
                            product.CreatedAt,
                            product.UpdatedAt,
                            product.Name.Value,
                            product.Price,
                            product.StockQuantity,
                            product.CategoryId,
                            category.Name.Value,
                            context.ProductUserLikes.Count(x => x.ProductId == product.Id)
                        )
                );
    }

    internal class ProductQueryRepository(AppDbContext context) : IProductQueryRepository
    {
        private readonly AppDbContext _context = context;

        public Task<ProductResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
            => _context.Products
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToProductResponseDto(_context)
                .FirstOrDefaultAsync(cancellationToken);

        public Task<List<ProductResponseDto>> GetAllAsync(Page page, CancellationToken cancellationToken)
            => _context.Products
                .AsNoTracking()
                .ToPage(page)
                .ToProductResponseDto(_context)
                .ToListAsync(cancellationToken);

        public Task<List<ProductResponseDto>> SearchAsync(string? key, Page page, CancellationToken cancellationToken)
            => _context.Products
                .AsNoTracking()
                .Where(x => key == null || x.Name.Value.ToLower().Contains(key.ToLower()))
                .ToPage(page)
                .ToProductResponseDto(_context)
                .ToListAsync(cancellationToken);

        public Task<List<ProductResponseDto>> GetByCategoryId(int categoryId, Page page, CancellationToken cancellationToken)
            => _context.Products
                .AsNoTracking()
                .Where(x => x.CategoryId == categoryId)
                .ToPage(page)
                .ToProductResponseDto(_context)
                .ToListAsync(cancellationToken);
    }
}
