using CampusPlacementManagement.Core.Common;
using CampusPlacementManagement.Core.Entities;
using CampusPlacementManagement.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
namespace CampusPlacementManagement.Infrastructure.Data.Seeding;
public static class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        string[] roles = { Roles.SuperAdmin, Roles.PlacementOfficer, Roles.CompanyHR, Roles.Student };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }
        var adminEmail = "admin@campusplacement.com";
        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin == null)
        {
            admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, FullName = "Platform Administrator", Status = AccountStatus.Approved, EmailConfirmed = true };
            var res = await userManager.CreateAsync(admin, "Admin@123456");
            if (res.Succeeded) await userManager.AddToRoleAsync(admin, Roles.SuperAdmin);
        }
    }
}
