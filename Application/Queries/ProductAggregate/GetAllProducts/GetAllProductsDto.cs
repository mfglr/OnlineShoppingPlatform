using Core;
using MediatR;

namespace Application.Queries.ProductAggregate.GetAllProducts
{
    public record GetAllProductsDto(int? Offset, int Take, bool IsDescending) : Page(Offset,Take,IsDescending), IRequest<List<ProductResponseDto>>;
}
