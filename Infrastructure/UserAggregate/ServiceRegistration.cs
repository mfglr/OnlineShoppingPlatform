using Domain.UserAggregate.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.UserAggregate
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddUserAggregateServices(this IServiceCollection services)
            => services
                .AddScoped<IAccessTokenGenerator, AccessTokenGenerator>()
                .AddScoped<IUserRepository, UserRepository>();
            
    }
}
