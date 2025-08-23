using Domain.CategoryAggregate.Abstracts;
using Domain.CategoryAggregate.Entities;
using Domain.CategoryAggregate.ValueObjects;
using MediatR;

namespace Application.Commands.CategoryAggregate.CreateCategory
{
    internal class CreateCategoryHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task Handle(CreateCategoryDto request, CancellationToken cancellationToken)
        {
            var categoryName = new CategoryName(request.Name);
            var category = new Category(categoryName);
            category.Create();
            await _categoryRepository.CreateAsync(category, cancellationToken);
        }
    }
}
