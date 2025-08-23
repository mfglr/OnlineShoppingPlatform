using Domain.CartAggregate.DomainServices;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.CartAggregate
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCartDomainServices(this IServiceCollection services)
            => services.AddScoped<CartItemAdder>();
    }
}
