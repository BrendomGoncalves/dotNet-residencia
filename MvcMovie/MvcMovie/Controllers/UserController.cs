using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Auth;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers;

public class UserController : Controller
{
    private readonly MvcMovieContext _context;
    private readonly IAuthService _authService;

    public UserController(MvcMovieContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    // GET: User
    public async Task<IActionResult> Index()
    {
        // return _context.User != null ? View(await _context.User.ToListAsync()) : Problem("Entity set 'MvcMovieContext.User'  is null.");
        return View(await _context.User.ToListAsync());
    }

    // GET: User/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        // if (id == null || _context.User == null)
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.User
            .FirstOrDefaultAsync(m => m.UserId == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // GET: User/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: User/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("UserId,Name,Email,Password")] User user)
    {
        if (ModelState.IsValid)
        {
            // var pass = user.Password;
            // using (var sha256 = SHA256.Create())
            // {
            //     var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
            //     var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            //     user.Password = hash;
            // }
            if (_context.User.FirstOrDefault(u => u.Email == user.Email) == null)
            {
                user.Password = _authService.ComputeSha256Hash(user.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } else ModelState.AddModelError("Email", "Email already exists.");
        }

        return View(user);
    }

    // GET: User/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        // if (id == null || _context.User == null)
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // POST: User/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,Email,Password")] User user)
    {
        if (id != user.UserId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                user.Password = _authService.ComputeSha256Hash(user.Password);
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }

    // GET: User/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        // if (id == null || _context.User == null)
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.User
            .FirstOrDefaultAsync(m => m.UserId == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        // if (_context.User == null)
        // {
        //     return Problem("Entity set 'MvcMovieContext.User'  is null.");
        // }

        var user = await _context.User.FindAsync(id);
        if (user != null)
        {
            _context.User.Remove(user);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UserExists(int id)
    {
        return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
    }
}
