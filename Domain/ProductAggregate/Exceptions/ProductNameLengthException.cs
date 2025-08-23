using Core.Exceptions;
using Domain.ProductAggregate.ValueObjects;
using System.Net;

namespace Domain.ProductAggregate.Exceptions
{
    public class ProductNameLengthException : AppException
    {
        private readonly static string _message = $"The product name length must be between {ProductName.MinLength} and {ProductName.MaxLength} characters.";
        public ProductNameLengthException() : base((int)HttpStatusCode.BadRequest, _message){}
    }
}
