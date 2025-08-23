using Domain.CategoryAggregate.Abstracts;
using Domain.CategoryAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;

namespace Infrastructure.CategoryAggregate
{
    internal class CategoryRepository(AppDbContext context) : Repository<Category>(context), ICategoryRepository
    {
    }
}
