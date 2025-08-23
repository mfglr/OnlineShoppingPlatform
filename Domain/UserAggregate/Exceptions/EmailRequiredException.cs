using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    public class EmailRequiredException : AppException
    {
        private readonly static string _message = "Email is required!";
        public EmailRequiredException() : base((int) HttpStatusCode.BadRequest, _message)
        {
        }
    }
}
