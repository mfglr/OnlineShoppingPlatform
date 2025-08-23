using Application.InfrastructureServices;
using Domain.UserAggregate.Entities;

namespace Infrastructure.InfrastructureServices
{
    internal class UserAccessor : IUserAccessor
    {
        public User User { get; set; } = null!;
    }
}
