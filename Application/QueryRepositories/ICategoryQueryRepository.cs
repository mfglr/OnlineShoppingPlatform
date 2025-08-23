using Application.Queries.CategoryAggregate;
using Core;

namespace Application.QueryRepositories
{
    public interface ICategoryQueryRepository
    {
        Task<List<CategoryResponseDto>> GetAllAsync(Page page, CancellationToken cancellationToken);
    }
}
