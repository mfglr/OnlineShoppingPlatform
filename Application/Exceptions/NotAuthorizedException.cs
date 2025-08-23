using Core.Exceptions;
using System.Net;

namespace Application.Exceptions
{
    public class NotAuthorizedException : AppException
    {
        private readonly static string _message = "You are not authorized!";
        public NotAuthorizedException() : base((int)HttpStatusCode.Unauthorized, _message) { }
    }
}
