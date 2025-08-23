using MediatR;

namespace Application.Commands.UserAggregate.ConfirmEmail
{
    public record ConfirmEmailDto(string Token) : IRequest;
}
