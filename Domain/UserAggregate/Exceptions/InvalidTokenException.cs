using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    internal class InvalidTokenException()
        : AppException((int)HttpStatusCode.BadRequest, "The code is incorrect or no longer valid!");
}
