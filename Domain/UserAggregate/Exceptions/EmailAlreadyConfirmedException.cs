using Core.Exceptions;
using System.Net;

namespace Domain.UserAggregate.Exceptions
{
    internal class EmailAlreadyConfirmedException() : AppException((int)HttpStatusCode.BadRequest, "Your email has been already confirmed before!");
}
