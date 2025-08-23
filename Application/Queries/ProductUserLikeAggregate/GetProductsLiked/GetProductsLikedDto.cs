using Core;
using MediatR;

namespace Application.Queries.ProductUserLikeAggregate.GetProductsLiked
{
    public record GetProductsLikedDto(int? Offset, int Take, bool IsDescending) : Page(Offset, Take, IsDescending), IRequest<List<ProductUserLikeResponseDto>>;
}
