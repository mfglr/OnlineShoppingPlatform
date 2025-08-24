using Core;
using MediatR;

namespace Application.Queries.ProductAggregate.SearchProducts
{
    public record SearchProductsDto(string? Key, Guid? Offset, int Take, bool IsDescending) : Page(Offset,Take,IsDescending), IRequest<List<ProductResponseDto>>;
}
