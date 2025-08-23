using Application.Extentions;
using Core.Events;
using Domain.OrderAggregate.Abstracts;
using Domain.OrderAggregate.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.OrderAggregate.CancelOrder
{
    internal class CancelOrderHandler(IOrderRepository orderRepository, IPublisher publisher, IHttpContextAccessor contextAccessor) : IRequestHandler<CancelOrderDto>
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IPublisher _publisher = publisher;
        private readonly IHttpContextAccessor _contextAccessor = contextAccessor;

        public async Task Handle(CancelOrderDto request, CancellationToken cancellationToken)
        {
            var userId = _contextAccessor.HttpContext.GetRequiredUserId();
            var order =
                await _orderRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new OrderNotFoundException();

            if (order.UserId != userId)
                throw new OrderOwnershipViolationException();

            order.Cancel();

            await _publisher.Publish(
                new OrderCancelledEvent(
                    order.Id,
                    order.Items.Select(x => new OrderCancelledEvent_Item(x.ProductId,x.Quantity))
                ),
                cancellationToken
            );
        }
    }
}
