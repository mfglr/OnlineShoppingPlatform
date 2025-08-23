using Application.Commands.ProductAggragate.CreateProduct;
using Application.Commands.ProductAggragate.DeleteProduct;
using Application.Commands.ProductAggragate.IncreaseStockQuantity;
using Application.Queries.ProductAggregate;
using Application.Queries.ProductAggregate.GetAllProducts;
using Application.Queries.ProductAggregate.GetProductById;
using Application.Queries.ProductAggregate.GetProductsByCategoryId;
using Application.Queries.ProductAggregate.SearchProducts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingPlatform.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task Create(CreateProductDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task IncreaseStockQuantity(IncreaseStockQuantityDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task Delete(int id, CancellationToken cancellationToken)
            => await _sender.Send(new DeleteProductDto(id), cancellationToken);

        [HttpGet("{id}")]
        public async Task<ProductResponseDto> GetById(int id, CancellationToken cancellationToken)
            => await _sender.Send(new GetProductByIdDto(id), cancellationToken);

        [HttpGet]
        public async Task<List<ProductResponseDto>> GetAll([FromQuery] int? offset, [FromQuery] int take, [FromQuery] bool isDescending, CancellationToken cancellationToken)
            => await _sender.Send(new GetAllProductsDto(offset,take, isDescending), cancellationToken);

        [HttpGet("{key}")]
        public async Task<List<ProductResponseDto>> Search(string key, [FromQuery] int? offset, [FromQuery] int take, [FromQuery] bool isDescending, CancellationToken cancellationToken)
            => await _sender.Send(new SearchProductsDto(key, offset, take, isDescending), cancellationToken);

        [HttpGet("{categoryId}")]
        public async Task<List<ProductResponseDto>> GetByCategoryId(int categoryId, [FromQuery] int? offset, [FromQuery] int take, [FromQuery] bool isDescending, CancellationToken cancellationToken)
            => await _sender.Send(new GetProductsByCategoryIdDto(offset, take, isDescending, categoryId), cancellationToken);
    }
}
