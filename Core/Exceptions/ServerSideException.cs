using System.Net;

namespace Core.Exceptions
{
    public class ServerSideException : AppException
    {
        private readonly static string _message = "Something went wrong! Please try again!";

        public ServerSideException() : base((int)HttpStatusCode.InternalServerError, _message)
        {
        }
    }
}
