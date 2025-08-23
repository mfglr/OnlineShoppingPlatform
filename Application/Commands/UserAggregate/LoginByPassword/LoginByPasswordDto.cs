using MediatR;

namespace Application.Commands.UserAggregate.LoginByPassword
{
    public record LoginByPasswordDto(string Email, string Password) : IRequest<LoginByPasswordResponseDto>;
}
