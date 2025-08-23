using Core.Exceptions;
using System.Net;

namespace Domain.CartAggregate.Exceptions
{
    internal class CartItemQuantityException()
        : AppException((int)HttpStatusCode.BadRequest, "The quantity of an cart item must be greater than 0!");
}
