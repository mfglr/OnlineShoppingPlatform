using Domain.UserAggregate.Entities;

namespace Domain.UserAggregate.Abstracts
{
    public interface IAccessTokenGenerator
    {
        string Generate(User user);
    }
}
