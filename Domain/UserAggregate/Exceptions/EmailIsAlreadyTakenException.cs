using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    public class EmailIsAlreadyTakenException : AppException
    {
        private readonly static string _message = "The email has been already taken!";
        public EmailIsAlreadyTakenException() : base((int)HttpStatusCode.BadRequest, _message) { }
    }
}
