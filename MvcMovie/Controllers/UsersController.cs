using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Data.Auth;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class UsersController : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly IAuthService _authService;

        public UsersController(MvcMovieContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: Users
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            
            if (user == null) return NotFound();

            return View(user);
        }

        // GET: Users/Create
        [Authorize(Policy = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Create([Bind("UserId,Name,Email,Password")] User user)
        {
            if (!ModelState.IsValid) return View(user);
            
            if (_context.User.FirstOrDefault(u => u.Email == user.Email) == null)
            {
                if (user.Password != null) user.Password = _authService.ComputeSha256Hash(user.Password);
                else ModelState.AddModelError("Password", "Password is required.");
                
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("Email", "Email already exists.");
            return View(user);
        }

        // GET: Users/Edit/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,Email,Password")] User user)
        {
            if (id != user.UserId) return NotFound();
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (user.Password != null) user.Password = _authService.ComputeSha256Hash(user.Password);
                    else ModelState.AddModelError("Password", "Password is required.");
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
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

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
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
}
