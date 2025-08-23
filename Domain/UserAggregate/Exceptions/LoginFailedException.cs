using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    public class LoginFailedException : AppException
    {
        private readonly static string _message = "Email or password is incorrect!";

        public LoginFailedException() : base((int)HttpStatusCode.BadRequest, _message)
        {
        }
    }
}
