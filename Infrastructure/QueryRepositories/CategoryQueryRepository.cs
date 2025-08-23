using Application.Queries.CategoryAggregate;
using Application.QueryRepositories;
using Core;
using Domain.CategoryAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryRepositories
{
    internal static class CategoryQueryableMappers
    {
        public static IQueryable<CategoryResponseDto> ToCategoryResponseDto(this IQueryable<Category> query, AppDbContext context)
            => query
                .Select(
                    category => 
                        new CategoryResponseDto(
                            category.Id,
                            category.Name.Value,
                            context.Products.Count(product => product.CategoryId == category.Id)
                        )
                );

    }

    internal class CategoryQueryRepository(AppDbContext context) : ICategoryQueryRepository
    {
        private readonly AppDbContext _context = context;

        public Task<List<CategoryResponseDto>> GetAllAsync(Page page, CancellationToken cancellationToken)
            => _context.Categories
                .AsNoTracking()
                .ToPage(page)
                .ToCategoryResponseDto(_context)
                .ToListAsync(cancellationToken);
    }
}
