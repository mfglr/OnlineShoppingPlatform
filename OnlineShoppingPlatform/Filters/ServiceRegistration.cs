namespace OnlineShoppingPlatform.Filters
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddFilters(this IServiceCollection services)
            => services
                .AddScoped<UserNotFoundFilter>();
    }
}
