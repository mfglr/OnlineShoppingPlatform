using MediatR;

namespace Application.Commands.CategoryAggregate.UpdateCategoryName
{
    public record UpdateCategoryNameDto(Guid Id, string Name) : IRequest;
}
