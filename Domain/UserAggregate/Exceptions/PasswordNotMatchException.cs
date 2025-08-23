using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    public class PasswordNotMatchException() : AppException((int)HttpStatusCode.BadRequest, "Password not match!");
}
