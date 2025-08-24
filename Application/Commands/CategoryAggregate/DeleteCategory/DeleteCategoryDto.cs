using MediatR;

namespace Application.Commands.CategoryAggregate.DeleteCategory
{
    public record DeleteCategoryDto(Guid CategoryId) : IRequest;
}
