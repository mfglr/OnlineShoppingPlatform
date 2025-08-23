using Core.Exceptions;
using System.Net;

namespace Domain.ProductAggregate.Exceptions
{
    public class ProductDecimalException : AppException
    {
        private readonly static string _message = "The price of a product must be greater than 0!";
        public ProductDecimalException() : base((int)HttpStatusCode.BadRequest, _message)
        {
        }
    }
}
