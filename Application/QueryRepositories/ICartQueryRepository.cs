using Application.Queries.CartAggregate;

namespace Application.QueryRepositories
{
    public interface ICartQueryRepository
    {
        Task<CartResponseDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
