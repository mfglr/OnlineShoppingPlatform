using Application.QueryRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.QueryRepositories
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddQueryRepositories(this IServiceCollection services)
            => services
                .AddScoped<IProductQueryRepository, ProductQueryRepository>()
                .AddScoped<ICartQueryRepository, CartQueryRepository>()
                .AddScoped<IOrderQueryRepository, OrderQueryRepository>()
                .AddScoped<ICategoryQueryRepository, CategoryQueryRepository>()
                .AddScoped<IProductUserLikeQueryRepository, ProductUserLikeQueryRepository>();
    }
}
