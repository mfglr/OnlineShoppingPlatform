using Application.Commands.UserAggregate.ConfirmEmail;
using Application.Commands.UserAggregate.CreateUser;
using Application.Commands.UserAggregate.GenerateEmailConfirmationMail;
using Application.Commands.UserAggregate.GenereatePasswordResetToken;
using Application.Commands.UserAggregate.LoginByPassword;
using Application.Commands.UserAggregate.LoginByRefreshToken;
using Application.Commands.UserAggregate.ResetPassword;
using Application.Commands.UserAggregate.UpdateFirstName;
using Application.Commands.UserAggregate.UpdateLastName;
using Application.Commands.UserAggregate.UpdatePassword;
using Application.Commands.UserAggregate.UpdatePhoneNumber;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingPlatform.Filters;

namespace OnlineShoppingPlatform.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost]
        public async Task<CreateUserResponseDto> Create(CreateUserDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPost]
        public async Task<LoginByPasswordResponseDto> LoginByPassword(LoginByPasswordDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPost]
        public async Task<LoginByRefreshTokenResponseDto> LoginByRefreshToken(LoginByRefreshTokenDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(UserNotFoundFilter))]
        public async Task ConfirmEmail(ConfirmEmailDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(UserNotFoundFilter))]
        public async Task GenerateEmailConfirmationMail(CancellationToken cancellationToken)
            => await _sender.Send(new GenerateEmailConfirmationMailDto(), cancellationToken);

        [HttpPut]
        public async Task GeneratePasswordResetToken(GeneratePasswordResetTokenDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(UserNotFoundFilter))]
        public async Task UpdateFirstName(UpdateFirstNameDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(UserNotFoundFilter))]
        public async Task UpdateLastName(UpdateLastNameDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(UserNotFoundFilter))]
        public async Task UpdatePhoneNumber(UpdatePhoneNumberDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        [Authorize(Roles = "Customer, Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ServiceFilter(typeof(UserNotFoundFilter))]
        public async Task UpdatePassword(UpdatePasswordDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);

        [HttpPut]
        public async Task ResetPassword(ResetPasswordDto request, CancellationToken cancellationToken)
            => await _sender.Send(request, cancellationToken);
    }
}
