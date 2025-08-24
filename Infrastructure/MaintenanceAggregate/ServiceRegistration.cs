using Domain.MaintenanceAggregate.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.MaintenanceAggregate
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMaintenanceAggregateServices(this IServiceCollection services)
            => services
                .AddScoped<IMaintenanceRepository, MaintenanceRepository>();
    }
}
