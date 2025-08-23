using Application.Commands.OrderAggregate.CancelOrder;
using Application.Queries.OrderAggregate;
using Application.Queries.OrderAggregate.GetCancelledOrders;
using Application.Queries.OrderAggregate.GetOrders;
using Application.Queries.OrderAggregate.GetSuccessOrders;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingPlatform.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPut]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task Cancel(CancelOrderDto request, CancellationToken cancellationToken)
            => await _sender.Send(request,cancellationToken);

        [HttpGet]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<OrderResponseDto>> GetOrders([FromQuery]int? offset, [FromQuery]int take, [FromQuery]bool isDescending, CancellationToken cancellationToken)
            => await _sender.Send(new GetOrdersDto(offset, take, isDescending),cancellationToken);

        [HttpGet]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<OrderResponseDto>> GetCancelledOrders([FromQuery] int? offset, [FromQuery] int take, [FromQuery] bool isDescending, CancellationToken cancellationToken)
            => await _sender.Send(new GetCancelledOrdersDto(offset, take, isDescending), cancellationToken);

        [HttpGet]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<OrderResponseDto>> GetSuccessOrders([FromQuery] int? offset, [FromQuery] int take, [FromQuery] bool isDescending, CancellationToken cancellationToken)
            => await _sender.Send(new GetSuccessOrdersDto(offset, take, isDescending), cancellationToken);

    }
}
