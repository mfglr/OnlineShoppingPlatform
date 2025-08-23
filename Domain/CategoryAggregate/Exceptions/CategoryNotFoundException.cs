using Core.Exceptions;
using System.Net;

namespace Domain.CategoryAggregate.Exceptions
{
    public class CategoryNotFoundException() : AppException((int)HttpStatusCode.NotFound, "Category was not found!");
}
