using Application.Queries.ProductUserLikeAggregate;
using Core;

namespace Application.QueryRepositories
{
    public interface IProductUserLikeQueryRepository
    {
        Task<List<ProductUserLikeResponseDto>> GetByUserId(Guid userId, Page page, CancellationToken cancellationToken);
    }
}
