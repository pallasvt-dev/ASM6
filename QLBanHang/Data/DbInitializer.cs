using Microsoft.AspNetCore.Identity;
using QLBanHang.Models;

namespace QLBanHang.Data;

public static class DbInitializer
{
    public static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        string[] roleNames = { "Admin", "Member" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var adminEmail = "admin@admin.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = adminEmail,
                FullName = "Quản Trị Viên",
                Address = "TP.HCM"
            };
            var result = await userManager.CreateAsync(adminUser, "admin123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        var memberEmail = "member@member.com";
        var memberUser = await userManager.FindByEmailAsync(memberEmail);
        if (memberUser == null)
        {
            memberUser = new ApplicationUser
            {
                UserName = "member",
                Email = memberEmail,
                FullName = "Thành Viên",
                Address = "Hà Nội"
            };
            var result = await userManager.CreateAsync(memberUser, "member123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(memberUser, "Member");
            }
        }
    }
}
