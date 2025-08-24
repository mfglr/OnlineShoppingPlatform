using Domain.MaintenanceAggregate.Abstracts;
using Domain.MaintenanceAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;

namespace Infrastructure.MaintenanceAggregate
{
    internal class MaintenanceRepository(AppDbContext context) : Repository<Maintenance>(context), IMaintenanceRepository;
}
