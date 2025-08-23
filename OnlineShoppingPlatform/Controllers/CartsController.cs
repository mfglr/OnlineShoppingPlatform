using Application.Commands.CartAggregate.AddCartItem;
using Application.Commands.CartAggregate.ConfirmCart;
using Application.Commands.CartAggregate.DecreaseCartItem;
using Application.Commands.CartAggregate.IncreaseCartItem;
using Application.Commands.CartAggregate.RemoveCartItem;
using Application.Queries.CartAggregate;
using Application.Queries.CartAggregate.GetCart;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingPlatform.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CartsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPut]
        public async Task Confirm(CancellationToken cancellationToken)
            => await _sender.Send(new ConfirmCartDto(), cancellationToken);

        [HttpPut]
        public async Task AddItem(AddCartItemDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        public async Task RemoveItem(RemoveCartItemDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        public async Task IncreaseItem(IncreaseCartItemDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        public async Task DecreaseItem(DecreaseCartItemDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpGet]
        public async Task<CartResponseDto> Get(CancellationToken cancellationToken)
            => await _sender.Send(new GetCartDto(), cancellationToken);
    }
}
