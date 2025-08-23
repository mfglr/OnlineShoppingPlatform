using Application.Queries.ProductAggregate;
using Core;

namespace Application.QueryRepositories
{
    public interface IProductQueryRepository
    {
        Task<ProductResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<ProductResponseDto>> GetAllAsync(Page page, CancellationToken cancellationToken);
        Task<List<ProductResponseDto>> SearchAsync(string? key, Page page, CancellationToken cancellationToken);
        Task<List<ProductResponseDto>> GetByCategoryId(int categoryId, Page page, CancellationToken cancellationToken);
    }
}
