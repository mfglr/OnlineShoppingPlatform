using Core.Exceptions;
using System.Net;

namespace Domain.CartAggregate.Exceptions
{
    internal class InsufficientStockException() : AppException((int)HttpStatusCode.BadRequest, "Insufficient stock!");
}
