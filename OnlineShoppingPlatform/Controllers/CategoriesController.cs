using Application.Commands.CategoryAggregate.CreateCategory;
using Application.Commands.CategoryAggregate.DeleteCategory;
using Application.Commands.CategoryAggregate.UpdateCategoryName;
using Application.Queries.CategoryAggregate;
using Application.Queries.CategoryAggregate.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingPlatform.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task Create(CreateCategoryDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
            => await _sender.Send(new DeleteCategoryDto(id), cancellationToken);

        [HttpPut]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task UpdateName(UpdateCategoryNameDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpGet]
        public async Task<List<CategoryResponseDto>> GetAll([FromQuery] Guid? offset, [FromQuery]int take, [FromQuery]bool isDescending, CancellationToken cancellationToken)
            => await _sender.Send(new GetAllCategoriesDto(offset, take, isDescending), cancellationToken);
    }
}
