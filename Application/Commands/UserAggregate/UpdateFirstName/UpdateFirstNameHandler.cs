using Application.InfrastructureServices;
using MediatR;

namespace Application.Commands.UserAggregate.UpdateFirstName
{
    internal class UpdateFirstNameHandler(IUserAccessor userAccessor) : IRequestHandler<UpdateFirstNameDto>
    {
        private readonly IUserAccessor _userAccessor = userAccessor;

        public Task Handle(UpdateFirstNameDto request, CancellationToken cancellationToken)
        {
            _userAccessor.User.UpdateFirstName(request.FirstName);
            return Task.CompletedTask;
        }
    }
}
