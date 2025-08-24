using Application.InfrastructureServices;
using Domain.UserAggregate.Abstracts;
using Domain.UserAggregate.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Application.Extentions;

namespace OnlineShoppingPlatform.Filters
{
    public class UserNotFoundFilter(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IUserAccessor userAccessor) : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserAccessor _userAccessor = userAccessor;

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = _httpContextAccessor.HttpContext.GetRequiredUserId();
            var user =
                await _userRepository.GetByIdAsync(userId, CancellationToken.None) ??
                throw new UserNotFoundException();
            _userAccessor.User = user;
            await next();
        }

    }
}
