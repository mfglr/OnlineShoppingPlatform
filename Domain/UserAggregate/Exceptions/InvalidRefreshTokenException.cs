using Core.Exceptions;

namespace Domain.UserAggregate.Exceptions
{
    internal class InvalidRefreshTokenException : AppException
    {
        private readonly static string _message = "The refresh token is not valid!";
        public InvalidRefreshTokenException() : base(419, _message)
        {
        }
    }
}
