using Domain.OrderAggregate.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.OrderAggregate
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddOrderAggregateServices(this IServiceCollection services)
            => services
                .AddScoped<IOrderRepository, OrderRepository>();
    }
}
