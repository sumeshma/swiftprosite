using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SwiftPro.Models.Identity;

namespace SwiftPro.Data.Seed;

public static class IdentitySeeder
{
    public static async Task SeedAdminAsync(IServiceProvider services)
    {
        var userManager =
            services.GetRequiredService<UserManager<ApplicationUser>>();

        var roleManager =
            services.GetRequiredService<RoleManager<IdentityRole>>();

        var roles = new[] { "Admin", "Editor", "Manager" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        var email = "admin@swiftpro.com";

        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
        {
            user = new ApplicationUser
            {
                FullName = "System Admin",
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(
                user,
                "Admin@123");
        }

        if (!await userManager.IsInRoleAsync(user, "Admin"))
            await userManager.AddToRoleAsync(user, "Admin");
    }
}
