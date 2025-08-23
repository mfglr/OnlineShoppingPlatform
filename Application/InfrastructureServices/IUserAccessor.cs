using Domain.UserAggregate.Entities;

namespace Application.InfrastructureServices
{
    public interface IUserAccessor
    {
        User User { get; set; }
    }
}
