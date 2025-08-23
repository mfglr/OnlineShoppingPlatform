using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    public class UserNotFoundException : AppException
    {
        private readonly static string _message = "The user was not found!";

        public UserNotFoundException() : base((int)HttpStatusCode.NotFound, _message) { }
    }
}
