using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    public class InvalidPhoneNumberException : AppException
    {
        private readonly static string _message = "The phone number is invalid!";
        public InvalidPhoneNumberException() : base((int)HttpStatusCode.BadRequest, _message)
        {
        }
    }
}
