using Domain.CategoryAggregate.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CategoryAggregate
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddCategoryAggregateServices(this IServiceCollection services)
            => services
                .AddScoped<ICategoryRepository, CategoryRepository>();
    }
}
