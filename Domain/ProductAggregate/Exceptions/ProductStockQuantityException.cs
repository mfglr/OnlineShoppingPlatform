using Core.Exceptions;
using System.Net;

namespace Domain.ProductAggregate.Exceptions
{
    public class ProductStockQuantityException : AppException
    {
        private readonly static string _message = "The stock quantity of a product must be greater than zero!";
        public ProductStockQuantityException() : base((int)HttpStatusCode.BadRequest, _message)
        {
        }
    }
}
