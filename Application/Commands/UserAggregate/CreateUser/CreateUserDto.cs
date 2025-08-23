using MediatR;

namespace Application.Commands.UserAggregate.CreateUser
{
    public record CreateUserDto(string Email, string Password, string PasswordConfirm) : IRequest<CreateUserResponseDto>;
}
