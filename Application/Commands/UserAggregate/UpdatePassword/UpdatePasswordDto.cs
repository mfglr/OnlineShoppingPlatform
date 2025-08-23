using MediatR;

namespace Application.Commands.UserAggregate.UpdatePassword
{
    public record UpdatePasswordDto(string Password, string NewPassword) : IRequest;
}
