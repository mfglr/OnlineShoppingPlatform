using Core.Abstracts;
using Domain.UserAggregate.Entities;

namespace Domain.UserAggregate.Abstracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken);
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
