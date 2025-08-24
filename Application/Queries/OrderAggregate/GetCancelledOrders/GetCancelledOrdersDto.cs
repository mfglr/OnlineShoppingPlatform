using Core;
using MediatR;

namespace Application.Queries.OrderAggregate.GetCancelledOrders
{
    public record GetCancelledOrdersDto(Guid? Offset, int Take, bool IsDescending) : Page(Offset, Take, IsDescending), IRequest<List<OrderResponseDto>>;
}
