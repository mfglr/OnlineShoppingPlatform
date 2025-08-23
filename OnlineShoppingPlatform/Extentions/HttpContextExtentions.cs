using Core.Exceptions;
using System.Text;

namespace OnlineShoppingPlatform.Extentions
{
    public static class HttpContextExtentions
    {
        public static async Task WriteAppExceptionAsync(this HttpContext context, AppException ex)
        {
            var body = Encoding.UTF8.GetBytes(ex.Message);
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.Body.WriteAsync(body);
        }
    }
}
