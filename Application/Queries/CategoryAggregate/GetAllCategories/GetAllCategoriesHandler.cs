using Application.QueryRepositories;
using MediatR;

namespace Application.Queries.CategoryAggregate.GetAllCategories
{
    internal class GetAllCategoriesHandler(ICategoryQueryRepository categoryQueryRepository) : IRequestHandler<GetAllCategoriesDto,List<CategoryResponseDto>>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository = categoryQueryRepository;

        public Task<List<CategoryResponseDto>> Handle(GetAllCategoriesDto request, CancellationToken cancellationToken)
            => _categoryQueryRepository.GetAllAsync(request, cancellationToken);
    }
}
