using Core.Abstracts;
using Domain.CategoryAggregate.Entities;

namespace Domain.CategoryAggregate.Abstracts
{
    public interface ICategoryRepository : IRepository<Category>;
}
