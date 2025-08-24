using Application.Extentions;
using Core.Abstracts;
using Domain.MaintenanceAggregate.Abstracts;
using Domain.MaintenanceAggregate.Entities;

namespace OnlineShoppingPlatform.Middlewares
{
    public class MaintenanceMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context, IMaintenanceRepository maintenanceRepository,
                                  IUnitOfWork unitOfWork)
        {
            await _next(context);

            
            var statusCode = context.Response.StatusCode;
            
            if(statusCode >= 400)
            {
                string url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
                var ip = context.Connection.RemoteIpAddress?.ToString() ?? context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
                var userAgent = context.Request.Headers["User-Agent"].ToString();
                int? userId = context.GetUserId();

                var maintenance = new Maintenance(userId, userAgent, url, ip, statusCode);
                maintenance.Create();
                await maintenanceRepository.CreateAsync(maintenance, CancellationToken.None);
                await unitOfWork.CommitAsync(CancellationToken.None);
            }
            
        }
    }
}
