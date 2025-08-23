using Core.Exceptions;
using System.Net;

namespace Application.Exceptions
{
    internal class ProductNotFoundException : AppException
    {
        private readonly static string _message = "Product was not found!";
        public ProductNotFoundException() : base((int)HttpStatusCode.NotFound, _message)
        {
        }
    }
}
