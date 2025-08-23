using Core.Exceptions;
using System.Net;

namespace Domain.OrderAggregate.Exceptions
{
    public class OrderOwnershipViolationException : AppException
    {
        public OrderOwnershipViolationException() : base((int)HttpStatusCode.BadRequest, "You can only change the state of orders you own.")
        {
        }
    }
}
