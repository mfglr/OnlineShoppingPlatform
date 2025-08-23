using Domain.ProductUserLikeAggregate.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ProductUserLikeAggregate
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddProductUserLikeServices(this IServiceCollection services)
            => services
                .AddScoped<IProductUserLikeRepository, ProductUserLikeRepository>();
    }
}
