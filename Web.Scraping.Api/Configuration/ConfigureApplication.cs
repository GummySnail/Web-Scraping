using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Scraping.Infrastructure.Data;
using Web.Scraping.Infrastructure.Entities;

namespace Web.Scraping.Api.Configuration;

public static class ConfigureApplication
{
    public static WebApplication AddApplicationConfiguration(this WebApplication app, IConfiguration configuration)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(configuration["Jwt:Audience"]));
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }

    public static async Task AddDatabaseConfiguration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await context.Database.MigrateAsync();

            await DataSeeder.SetApplicationRoleConfiguration(roleManager);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Error during database migration");
        }
    }
}