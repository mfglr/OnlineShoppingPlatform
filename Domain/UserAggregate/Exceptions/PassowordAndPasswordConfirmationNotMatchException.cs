using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    public class PassowordAndPasswordConfirmationNotMatchException : AppException
    {
        private readonly static string _message = "Password and password confirmation do not match!";
        public PassowordAndPasswordConfirmationNotMatchException() : base((int)HttpStatusCode.BadRequest, _message) { }
    }
}
