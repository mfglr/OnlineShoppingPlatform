using Core;
using MediatR;

namespace Application.Queries.ProductAggregate.GetProductsByCategoryId
{
    public record GetProductsByCategoryIdDto(Guid? Offset, int Take, bool IsDescending, Guid CategoryId) : Page(Offset, Take, IsDescending), IRequest<List<ProductResponseDto>>;
}
