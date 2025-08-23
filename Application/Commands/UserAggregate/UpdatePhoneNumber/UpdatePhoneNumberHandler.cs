using Application.InfrastructureServices;
using Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Application.Commands.UserAggregate.UpdatePhoneNumber
{
    internal class UpdatePhoneNumberHandler(IUserAccessor userAccessor) : IRequestHandler<UpdatePhoneNumberDto>
    {
        private readonly IUserAccessor _userAccessor = userAccessor;

        public Task Handle(UpdatePhoneNumberDto request, CancellationToken cancellationToken)
        {
            var phoneNumber = new PhoneNumber(request.PhoneNumber);
            _userAccessor.User.UpdatePhoneNumber(phoneNumber);
            return Task.CompletedTask;
        }
    }
}
