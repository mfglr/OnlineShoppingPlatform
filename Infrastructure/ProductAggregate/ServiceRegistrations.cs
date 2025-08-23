using Domain.ProductAggregate.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ProductAggregate
{
    internal static class ServiceRegistrations
    {
        public static IServiceCollection AddProductAggregateServices(this IServiceCollection services) =>
            services
                .AddScoped<IProductRepository, ProductRepository>();
    }
}
