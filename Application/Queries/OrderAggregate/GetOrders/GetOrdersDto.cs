using Core;
using MediatR;

namespace Application.Queries.OrderAggregate.GetOrders
{
    public record GetOrdersDto(Guid? Offset, int Take, bool IsDescending) : Page(Offset, Take, IsDescending), IRequest<List<OrderResponseDto>>;
}
