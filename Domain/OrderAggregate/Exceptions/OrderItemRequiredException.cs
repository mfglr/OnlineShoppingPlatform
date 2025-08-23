using Core.Exceptions;
using System.Net;

namespace Domain.OrderAggregate.Exceptions
{
    internal class OrderItemRequiredException : AppException
    {
        private readonly static string _message = "At least one order item must be provided!";
        public OrderItemRequiredException() : base((int)HttpStatusCode.BadRequest, _message)
        {
        }
    }
}
