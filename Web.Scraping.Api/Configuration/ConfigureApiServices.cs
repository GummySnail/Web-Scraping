namespace Web.Scraping.Api.Configuration;

public static class ConfigureApiServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddCors();
        services.Configure<RouteOptions>(opt => opt.LowercaseUrls = true);
        services.AddCors();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAuthorization();

        return services;
    }
}