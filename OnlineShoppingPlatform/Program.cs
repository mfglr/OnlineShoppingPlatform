using Application;
using Infrastructure;
using Infrastructure.UserAggregate;
using OnlineShoppingPlatform.Extentions;
using OnlineShoppingPlatform.Filters;
using OnlineShoppingPlatform.Middlewares;
using Domain.CartAggregate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services
    .AddMemoryCache()
    .AddHttpContextAccessor()
    .AddConfigurations()
    .AddJWT()
    .AddFilters()
    .AddCartDomainServices()
    .AddApplicationServices()
    .AddInfrastructureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<GlobalErrorHandlerMiddleware>();
app.UseMiddleware<MaintenanceMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
