using Domain.CategoryAggregate.Abstracts;
using Domain.CategoryAggregate.Exceptions;
using Domain.CategoryAggregate.ValueObjects;
using MediatR;

namespace Application.Commands.CategoryAggregate.UpdateCategoryName
{
    internal class UpdateCategoryNameHandler(ICategoryRepository categoryRepository) : IRequestHandler<UpdateCategoryNameDto>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task Handle(UpdateCategoryNameDto request, CancellationToken cancellationToken)
        {
            var category = 
                await _categoryRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new CategoryNotFoundException();
            var categoryName = new CategoryName(request.Name);
            category.UpdateName(categoryName);
        }
    }
}
