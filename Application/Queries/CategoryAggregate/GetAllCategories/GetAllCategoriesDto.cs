using Core;
using MediatR;

namespace Application.Queries.CategoryAggregate.GetAllCategories
{
    public record GetAllCategoriesDto(int? Offset, int Take, bool IsDescending) : Page(Offset, Take, IsDescending), IRequest<List<CategoryResponseDto>>;
}
