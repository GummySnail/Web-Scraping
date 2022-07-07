using Web.Scraping.Core.Services;

namespace Web.Scraping.Api.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();

        return services;
    }
}