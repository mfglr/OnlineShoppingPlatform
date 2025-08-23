using Application.InfrastructureServices;
using MediatR;

namespace Application.Commands.UserAggregate.ConfirmEmail
{
    internal class ConfirmEmailHandler(IUserAccessor userAccessor) : IRequestHandler<ConfirmEmailDto>
    {
        private readonly IUserAccessor _userAccessor = userAccessor;

        public Task Handle(ConfirmEmailDto request, CancellationToken cancellationToken)
        {
            _userAccessor.User.ConfirmEmail(request.Token);
            return Task.CompletedTask;
        }
    }
}
