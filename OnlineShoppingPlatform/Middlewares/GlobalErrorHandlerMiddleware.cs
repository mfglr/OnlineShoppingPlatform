using Core.Exceptions;
using OnlineShoppingPlatform.Extentions;

namespace OnlineShoppingPlatform.Middlewares
{
    public class GlobalErrorHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                await context.WriteAppExceptionAsync(ex);
            }
            catch (Exception ex)
            {
                await context.WriteAppExceptionAsync(new ServerSideException());
            }
        }
    }
}
