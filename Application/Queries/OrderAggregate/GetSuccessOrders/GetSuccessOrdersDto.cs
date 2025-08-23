using Core;
using MediatR;

namespace Application.Queries.OrderAggregate.GetSuccessOrders
{
    public record GetSuccessOrdersDto(int? Offset, int Take, bool IsDescending) : Page(Offset, Take, IsDescending), IRequest<List<OrderResponseDto>>;
}
