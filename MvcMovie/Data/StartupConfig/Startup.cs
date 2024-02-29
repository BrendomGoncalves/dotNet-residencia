using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Data.StartupConfig;

public class Startup
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AdminCredentials? _adminCredentials;

    public Startup(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _adminCredentials = configuration.GetSection("AdminCredentials").Get<AdminCredentials>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        EnsureAdminUserExists().Wait();
    }

    private async Task EnsureAdminUserExists()
    {
        var adminUser = await _userManager.FindByNameAsync(_adminCredentials?.UserName!);

        if (adminUser == null)
        {
            var user = new IdentityUser { UserName = _adminCredentials?.UserName, Email = "admin@example.com" };
            var result = await _userManager.CreateAsync(user, _adminCredentials?.Password!);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to create 'admin' user");
            }
        }
    }
}

public class AdminCredentials
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}