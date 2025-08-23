using Application.InfrastructureServices;
using Core.Abstracts;
using Infrastructure.CartAggregate;
using Infrastructure.CategoryAggregate;
using Infrastructure.Contexts;
using Infrastructure.InfrastructureServices;
using Infrastructure.InfrastructureServices.EmailService;
using Infrastructure.OrderAggregate;
using Infrastructure.ProductAggregate;
using Infrastructure.ProductUserLikeAggregate;
using Infrastructure.QueryRepositories;
using Infrastructure.UserAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) =>
            services
                .AddAppDbContext()
                .AddCategoryAggregateServices()
                .AddUserAggregateServices()
                .AddOrderAggregateServices()
                .AddCartAggregateServices()
                .AddProductAggregateServices()
                .AddProductUserLikeServices()
                .AddQueryRepositories()
                .AddScoped<IUnitOfWork,UnitOfWork.UnitOfWork>()
                .AddScoped<IUserAccessor, UserAccessor>()
                .AddEmailService();
    }
}
