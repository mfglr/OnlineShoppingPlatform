using MediatR;

namespace Application.Commands.OrderAggregate.CancelOrder
{
    public record CancelOrderDto(int Id) : IRequest;
}
