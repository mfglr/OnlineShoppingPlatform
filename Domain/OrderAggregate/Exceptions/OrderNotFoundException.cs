using Core.Exceptions;
using System.Net;

namespace Domain.OrderAggregate.Exceptions
{
    public class OrderNotFoundException : AppException
    {
        public OrderNotFoundException() : base((int)HttpStatusCode.NotFound, "Order was not found!")
        {}
    }
}
