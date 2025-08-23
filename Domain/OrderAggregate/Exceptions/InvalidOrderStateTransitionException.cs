using Core.Exceptions;
using System.Net;

namespace Domain.OrderAggregate.Exceptions
{
    internal class InvalidOrderStateTransitionException : AppException
    {
        public InvalidOrderStateTransitionException() : base((int)HttpStatusCode.BadRequest, "Invalid order state transition!"){}
    }
}
