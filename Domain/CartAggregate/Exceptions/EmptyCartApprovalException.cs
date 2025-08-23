using Core.Exceptions;
using System.Net;

namespace Domain.CartAggregate.Exceptions
{
    public class EmptyCartApprovalException()
        : AppException((int)HttpStatusCode.BadRequest, "Cannot approve an order with an empty cart.");
}
