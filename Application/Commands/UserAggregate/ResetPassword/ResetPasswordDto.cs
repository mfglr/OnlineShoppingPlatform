using MediatR;

namespace Application.Commands.UserAggregate.ResetPassword
{
    public record ResetPasswordDto(string Email, string Token, string NewPassword) : IRequest;
}
