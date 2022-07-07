using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Scraping.Core.Interfaces.Data.Repositories;
using Web.Scraping.Infrastructure.Data;
using Web.Scraping.Infrastructure.Data.Repositories;
using Web.Scraping.Infrastructure.Entities;
using Web.Scraping.Infrastructure.Mapping;

namespace Web.Scraping.Api.Configuration;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();

        services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}