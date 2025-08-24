using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Extentions
{
    public static class HttpContextExtentions
    {
        public static Guid GetRequiredUserId(this HttpContext? context)
        {
            if(context == null) throw new NotAuthorizedException();

            var value =
                context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ??
                throw new NotAuthorizedException();
            return Guid.Parse(value);
        }

        public static Guid? GetUserId(this HttpContext? context)
        {
            var value = context?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if(value == null) return null;
            return Guid.Parse(value);
        }

    }
}
