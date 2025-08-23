using Application.Extentions;
using Application.QueryRepositories;
using Domain.OrderAggregate.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Queries.OrderAggregate.GetSuccessOrders
{
    internal class GetSuccessOrdersHandler(IHttpContextAccessor httpContextAccessor, IOrderQueryRepository orderQueryRepository) : IRequestHandler<GetSuccessOrdersDto, List<OrderResponseDto>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IOrderQueryRepository _orderQueryRepository = orderQueryRepository;

        public Task<List<OrderResponseDto>> Handle(GetSuccessOrdersDto request, CancellationToken cancellationToken)
            => 
                _orderQueryRepository.GetOrdersByUserIdAndStateAsync(
                    _httpContextAccessor.HttpContext.GetRequiredUserId(),
                    OrderState.Success,
                    request,
                    cancellationToken
                );
    }
}
