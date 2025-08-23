using Application.Extentions;
using Application.QueryRepositories;
using Domain.OrderAggregate.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Queries.OrderAggregate.GetCancelledOrders
{
    internal class GetCancelledOrdersHandler(IHttpContextAccessor httpContextAccessor, IOrderQueryRepository orderQueryRepository) : IRequestHandler<GetCancelledOrdersDto, List<OrderResponseDto>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IOrderQueryRepository _orderQueryRepository = orderQueryRepository;

        public Task<List<OrderResponseDto>> Handle(GetCancelledOrdersDto request, CancellationToken cancellationToken)
            => 
                _orderQueryRepository.GetOrdersByUserIdAndStateAsync(
                    _httpContextAccessor.HttpContext.GetRequiredUserId(),
                    OrderState.Cancelled,
                    request,
                    cancellationToken
                );
    }
}
