using MediatR;

namespace Application.Commands.OrderAggregate.CancelOrder
{
    public record CancelOrderDto(Guid Id) : IRequest;
}
