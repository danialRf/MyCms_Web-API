using Microsoft.AspNetCore.Identity;
using MyCmsWebApi2.Domain.Entities;

public class RoleSeeder
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    public RoleSeeder(RoleManager<IdentityRole<Guid>> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SeedAsync()
    {
        if (!await _roleManager.RoleExistsAsync("Admin") || !await _roleManager.RoleExistsAsync("User"))
        {
            await _roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
            await _roleManager.CreateAsync(new IdentityRole<Guid>("User"));

        }
    }
}