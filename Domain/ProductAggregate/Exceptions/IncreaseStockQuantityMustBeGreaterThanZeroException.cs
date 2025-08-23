using Core.Exceptions;
using System.Net;

namespace Domain.ProductAggregate.Exceptions
{
    internal class IncreaseStockQuantityMustBeGreaterThanZeroException : AppException
    {
        public IncreaseStockQuantityMustBeGreaterThanZeroException() : base((int) HttpStatusCode.BadRequest, "The value provided to increase the product's stock must be greater than zero.")
        {
        }
    }
}
