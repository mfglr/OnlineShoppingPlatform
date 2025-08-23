using Application.Extentions;
using Application.QueryRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Queries.OrderAggregate.GetOrders
{
    internal class GetOrdersHandler(IOrderQueryRepository orderQueryRepository, IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetOrdersDto, List<OrderResponseDto>>
    {
        private readonly IOrderQueryRepository _orderQueryRepository = orderQueryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public Task<List<OrderResponseDto>> Handle(GetOrdersDto request, CancellationToken cancellationToken)
            => 
                _orderQueryRepository.GetOrdersByUserIdAsync(
                    _httpContextAccessor.HttpContext.GetRequiredUserId(),
                    request,
                    cancellationToken
                );
    }
}
