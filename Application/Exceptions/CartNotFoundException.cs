using Core.Exceptions;
using System.Net;

namespace Application.Exceptions
{
    internal class CartNotFoundException : AppException
    {
        private readonly static string _message = "Cart not found!";
        public CartNotFoundException() : base((int)HttpStatusCode.NotFound, _message)
        {
        }
    }
}
