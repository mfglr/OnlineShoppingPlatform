using Core.Exceptions;
using System.Net;

namespace Domain.OrderAggregate.Exceptions
{
    public class OrderItemQuantityException : AppException
    {
        private readonly static string _message = "The quantity of an order item must be greater than 0!";
        public OrderItemQuantityException() : base((int)HttpStatusCode.BadRequest, _message)
        {
        }
    }
}
