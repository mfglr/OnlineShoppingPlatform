using Core.Exceptions;
using System.Net;

namespace Domain.CartAggregate.Exceptions
{
    internal class CartItemNotFoundException()
        : AppException((int)HttpStatusCode.NotFound, "The product has not been found in your cart!");
}
