using MediatR;

namespace Application.Commands.UserAggregate.UpdateFirstName
{
    public record UpdateFirstNameDto(string FirstName) : IRequest;
}
