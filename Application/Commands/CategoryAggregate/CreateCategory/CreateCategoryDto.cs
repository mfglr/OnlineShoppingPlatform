using MediatR;

namespace Application.Commands.CategoryAggregate.CreateCategory
{
    public record CreateCategoryDto(string Name) : IRequest;
}
