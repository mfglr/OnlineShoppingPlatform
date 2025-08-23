using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    public class InvalidEmailException : AppException
    {
        private readonly static string _message = "The email is invalid!";
        public InvalidEmailException() : base((int)HttpStatusCode.BadRequest,_message) { }
    }
}
