using MediatR;

namespace Application.Commands.UserAggregate.UpdateLastName
{
    public record UpdateLastNameDto(string? LastName) : IRequest;
}
