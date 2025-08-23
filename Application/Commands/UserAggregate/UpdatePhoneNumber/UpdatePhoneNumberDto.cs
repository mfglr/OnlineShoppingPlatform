using MediatR;

namespace Application.Commands.UserAggregate.UpdatePhoneNumber
{
    public record UpdatePhoneNumberDto(string PhoneNumber) : IRequest;
}
