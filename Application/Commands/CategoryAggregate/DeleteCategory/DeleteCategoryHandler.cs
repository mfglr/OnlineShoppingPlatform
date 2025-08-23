using Core.Events;
using Domain.CategoryAggregate.Abstracts;
using Domain.CategoryAggregate.Exceptions;
using MediatR;

namespace Application.Commands.CategoryAggregate.DeleteCategory
{
    internal class DeleteCategoryHandler(ICategoryRepository categoryRepository, IPublisher publisher) : IRequestHandler<DeleteCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IPublisher _publisher = publisher;

        public async Task Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
        {
            var category =
                await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken) ??
                throw new CategoryNotFoundException();
            _categoryRepository.Delete(category);
            await _publisher.Publish(new CategoryDeletedEvent(category.Id), cancellationToken);
        }
    }
}
