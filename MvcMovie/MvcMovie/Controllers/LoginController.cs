using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Auth;
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
            var _passHashed = _authService.ComputeSha256Hash(user.Password);
            var userExists = await _context.User.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == _passHashed);
            
            if (userExists != null)
            {
                string _token = _authService.GenerateJwtToken(user.Email, "User");
                return RedirectToAction("LoginSuccess", "Login");
            }
            ModelState.AddModelError("Email", "Invalid email or password.");
        }
        return View("Login");
    }

}
