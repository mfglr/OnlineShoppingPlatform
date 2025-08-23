using Domain.UserAggregate.Abstracts;
using Domain.UserAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UserAggregate
{
    internal class UserRepository(AppDbContext context) : Repository<User>(context), IUserRepository
    {
        public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
            => _context.Users.FirstOrDefaultAsync(x => x.Email.Value == email,cancellationToken);

        public Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken)
            => _context.Users.AnyAsync(x => x.Email.Value == email && x.IsEmailConfirmed, cancellationToken);
    }
}
