using Core;
using MediatR;

namespace Application.Queries.ProductAggregate.GetProductsByCategoryId
{
    public record GetProductsByCategoryIdDto(int? Offset, int Take, bool IsDescending, int CategoryId) : Page(Offset, Take, IsDescending), IRequest<List<ProductResponseDto>>;
}
