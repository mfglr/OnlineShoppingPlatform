using Application.Commands.ProductUserLikeAggregate.DislikeProduct;
using Application.Commands.ProductUserLikeAggregate.LikeProduct;
using Application.Queries.ProductUserLikeAggregate;
using Application.Queries.ProductUserLikeAggregate.GetProductsLiked;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingPlatform.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductUserLikesController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task Create(LikeProductDto request,CancellationToken cancellationToken)
            => await _sender.Send(request,cancellationToken);

        [HttpDelete("{productId}")]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task Delete(Guid productId, CancellationToken cancellationToken)
            => await _sender.Send(new DislikeDto(productId), cancellationToken);

        [HttpGet]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<ProductUserLikeResponseDto>> Get([FromQuery] Guid? offset, [FromQuery]int take, [FromQuery]bool isDescending, CancellationToken cancellationToken)
            => await _sender.Send(new GetProductsLikedDto(offset,take,isDescending), cancellationToken);
    }
}
