using Core.Exceptions;
using System.Net;

namespace Domain.CartAggregate.Exceptions
{
    internal class InvalidCartStateTransitionException : AppException
    {
        public InvalidCartStateTransitionException() : base((int)HttpStatusCode.BadRequest, "Invalid cart state transition!")
        {
        }
    }
}
