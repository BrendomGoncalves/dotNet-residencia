using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data.Auth;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class LoginController : Controller
{
    private readonly MvcMovieContext _context;
    private readonly IAuthService _authService;

    public LoginController(MvcMovieContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public Task<IActionResult> Index()
    {
        // return _context.User != null ? View(await _context.User.ToListAsync()) : Problem("Entity set 'MvcMovieContext.User'  is null.");
        return Task.FromResult<IActionResult>(View("Login"));
    }

    public Task<IActionResult> LoginSuccess()
    {
        return Task.FromResult<IActionResult>(View());
    }

    // POST: Login
    [HttpPost("Login")]
    public async Task<IActionResult> Login([Bind("Email,Password")] User user)
    {
        if (ModelState.IsValid)
        {
            if (user.Password != null)
            {
                if (user.Email != null)
                {
                    user.Password = _authService.ComputeSha256Hash(user.Password);
                    var userExist =
                        await _context.User.FirstOrDefaultAsync(u =>
                            u.Email == user.Email && u.Password == user.Password);
                    if (userExist != null && userExist.Email == user.Email && userExist.Password == user.Password)
                    {
                        var claims = new List<Claim>
                        {
                            new(ClaimTypes.Name, userExist.Email),
                            new("FullName", userExist.Name ?? userExist.Email),
                            new(ClaimTypes.Role, userExist.Name == "admin" ? "Administrator" : "User")
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                            IsPersistent = false,
                            RedirectUri = "/Home"
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);
                        
                        return RedirectToAction("LoginSuccess", "Login");
                    }
                }
                else ModelState.AddModelError(string.Empty, "Usuário não existe");
            }
            else ModelState.AddModelError("Password", "Insira uma senha");
        }
        return View("Login");
    }

    public IActionResult Sair()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}