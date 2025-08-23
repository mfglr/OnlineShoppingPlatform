using MediatR;

namespace Application.Commands.CategoryAggregate.DeleteCategory
{
    public record DeleteCategoryDto(int CategoryId) : IRequest;
}
