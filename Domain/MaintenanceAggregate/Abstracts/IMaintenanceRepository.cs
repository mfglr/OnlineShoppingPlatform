using Core.Abstracts;
using Domain.MaintenanceAggregate.Entities;

namespace Domain.MaintenanceAggregate.Abstracts
{
    public interface IMaintenanceRepository : IRepository<Maintenance>;
}
