using Core.Exceptions;
using Domain.CategoryAggregate.ValueObjects;
using System.Net;

namespace Domain.CategoryAggregate.Exceptions
{
    internal class CategoryNameException() : AppException((int)HttpStatusCode.BadRequest, $"The name of a category must be between {CategoryName.MaxLength} and {CategoryName.MaxLength} length!");
}
