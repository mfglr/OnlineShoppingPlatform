using Domain.CartAggregate.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CartAggregate
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddCartAggregateServices(this IServiceCollection services)
            => services
                .AddScoped<ICartRepository, CartRepository>()
                .AddScoped<ICartProductService, CartProductService>();
    }
}
