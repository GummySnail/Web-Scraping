using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Web.Scraping.Infrastructure.Data;

public class DataSeeder
{
    public static async Task SetApplicationRoleConfiguration(RoleManager<IdentityRole> roleManager)
    {
        if(await roleManager.Roles.AnyAsync()) return;

        var roles = new List<IdentityRole>
        {
            new IdentityRole { Name = "User" },
            new IdentityRole { Name = "Admin" }
        };

        foreach (var role in roles)
        {
            await roleManager.CreateAsync(role);
        }
    }
}