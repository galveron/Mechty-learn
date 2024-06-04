using Mechty_learn_backend.Models;
using Microsoft.AspNetCore.Identity;

namespace Mechty_learn_backend.Data;

public class AuthenticationSeeder
{
    private readonly UserManager<Adult> _adultManager;
    private readonly IConfigurationRoot _config;
    
    public AuthenticationSeeder(UserManager<Adult> adultManager)
    {
        _adultManager = adultManager;
        _config = new ConfigurationBuilder()
            .AddUserSecrets<AuthenticationSeeder>()
            .Build();
    }
    
    public void AddAdmin()
    {
        var tAdmin = CreateAdminIfNotExists();
        tAdmin.Wait();
    }

    async Task CreateAdminIfNotExists()
    {
        var adminInDb = await _adultManager.FindByEmailAsync("admin@admin.com");
        if (adminInDb == null)
        {
            var admin = new Adult { UserName = "admin", Email = "admin@admin.com" };
            var adminCreated = await _adultManager.CreateAsync(admin, _config["AdminPassword"] != null ? _config["AdminPassword"] : Environment.GetEnvironmentVariable("ADMINPASSWORD"));
        }
    }
}