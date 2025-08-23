using Core.Exceptions;
using System.Net;

namespace Domain.ProductUserLikeAggregate.Exceptions
{
    public class ProductAlreadyDislikedException() : AppException((int)HttpStatusCode.BadRequest, "You already didn't like the product."); 
}
