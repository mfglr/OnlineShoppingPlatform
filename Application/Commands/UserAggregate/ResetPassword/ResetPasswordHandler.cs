using Domain.UserAggregate.Abstracts;
using Domain.UserAggregate.Exceptions;
using MediatR;

namespace Application.Commands.UserAggregate.ResetPassword
{
    internal class ResetPasswordHandler(IUserRepository userRepository) : IRequestHandler<ResetPasswordDto>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task Handle(ResetPasswordDto request, CancellationToken cancellationToken)
        {
            var user =
                await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken) ??
                throw new UserNotFoundException();
            user.ResetPassword(request.Token, request.NewPassword);
        }
    }
}
