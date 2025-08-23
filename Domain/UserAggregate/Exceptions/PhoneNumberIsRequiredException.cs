using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    public class PhoneNumberIsRequiredException : AppException
    {
        private readonly static string _message = "Phone number is required!";
        public PhoneNumberIsRequiredException() : base((int)HttpStatusCode.BadRequest, _message)
        {
        }
    }
}
