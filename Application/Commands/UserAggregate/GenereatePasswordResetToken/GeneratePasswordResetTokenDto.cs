using MediatR;

namespace Application.Commands.UserAggregate.GenereatePasswordResetToken
{
    public record GeneratePasswordResetTokenDto(string Email) : IRequest;
}
