using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    class InvalidPasswordException : AppException
    {
        private readonly static string _message = $"Your password must be at least 6 characters long.";
        public InvalidPasswordException() : base((int)HttpStatusCode.BadRequest, _message){ }
    }
}
