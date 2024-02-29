using Microsoft.EntityFrameworkCore;
using MvcMovie.Data.Auth;
using MvcMovie.Models;

namespace MvcMovie.Data.StartupConfig;

public class Startup
{
    private readonly AdminCredentials? _adminCredentials;
    private readonly MvcMovieContext _context;
    private readonly IAuthService _authService;

    public Startup(IConfiguration configuration, MvcMovieContext context, IAuthService authService)
    {
        _adminCredentials = configuration.GetSection("AdminCredentials").Get<AdminCredentials>();
        _context = context;
        _authService = authService;
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        EnsureAdminUserExists().Wait();
    }

    private async Task EnsureAdminUserExists()
    {
        var user = new User
        {
            Name = "admin",
            Email = _adminCredentials?.UserName,
            Password = _adminCredentials?.Password
        };
        var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email);
        if(existingUser == null)
        {
            if (user.Password != null) user.Password = _authService.ComputeSha256Hash(user.Password);
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}