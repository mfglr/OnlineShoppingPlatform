namespace Core.Exceptions
{
    public abstract class AppException(int statusCode, string message) : Exception(message)
    {
        public int StatusCode { get; private set; } = statusCode;
    }
}
