using Application.InfrastructureServices;
using MediatR;

namespace Application.Commands.UserAggregate.UpdateLastName
{
    internal class UpdateLastNameHandler(IUserAccessor userAccessor) : IRequestHandler<UpdateLastNameDto>
    {
        private readonly IUserAccessor _userAccessor = userAccessor;

        public Task Handle(UpdateLastNameDto request, CancellationToken cancellationToken)
        {
            _userAccessor.User.UpdateLastName(request.LastName);
            return Task.CompletedTask;
        }
    }
}
