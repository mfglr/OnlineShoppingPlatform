using Application.InfrastructureServices;
using MediatR;

namespace Application.Commands.UserAggregate.UpdatePassword
{
    internal class UpdatePasswordHandler(IUserAccessor userAccessor) : IRequestHandler<UpdatePasswordDto>
    {
        private readonly IUserAccessor _userAccessor = userAccessor;

        public Task Handle(UpdatePasswordDto request, CancellationToken cancellationToken)
        {
            _userAccessor.User.UpdatePassword(request.Password, request.NewPassword);
            return Task.CompletedTask;
        }
    }
}
