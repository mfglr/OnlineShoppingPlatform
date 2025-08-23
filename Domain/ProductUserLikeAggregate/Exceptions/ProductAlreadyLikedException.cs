using Core.Exceptions;
using System.Net;

namespace Domain.ProductUserLikeAggregate.Exceptions
{
    public class ProductAlreadyLikedException() : AppException((int)HttpStatusCode.BadRequest, "You have already liked the product before!");
}
