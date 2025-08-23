using MediatR;

namespace Application.Commands.CategoryAggregate.UpdateCategoryName
{
    public record UpdateCategoryNameDto(int Id, string Name) : IRequest;
}
