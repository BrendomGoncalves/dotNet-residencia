using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class StudiosController : Controller
    {
        private readonly MvcMovieContext _context;

        public StudiosController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Studios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Studio.ToListAsync());
        }

        // GET: Studios/Details/5
        [Authorize(Policy = "Administrator")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio
                .FirstOrDefaultAsync(m => m.StudioId == id);
            if (studio == null)
            {
                return NotFound();
            }

            return View(studio);
        }

        // GET: Studios/Create
        [Authorize(Policy = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Create([Bind("StudioId,Name,Country,Site")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studio);
        }

        // GET: Studios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio.FindAsync(id);
            if (studio == null)
            {
                return NotFound();
            }
            return View(studio);
        }

        // POST: Studios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("StudioId,Name,Country,Site")] Studio studio)
        {
            if (id != studio.StudioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudioExists(studio.StudioId))
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
            return View(studio);
        }

        // GET: Studios/Delete/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio
                .FirstOrDefaultAsync(m => m.StudioId == id);
            if (studio == null)
            {
                return NotFound();
            }

            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Studio == null)
            {
                return Problem("Entity set 'MvcMovieContext.Studio'  is null.");
            }
            var studio = await _context.Studio.FindAsync(id);
            if (studio != null)
            {
                _context.Studio.Remove(studio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudioExists(int id)
        {
          return (_context.Studio?.Any(e => e.StudioId == id)).GetValueOrDefault();
        }
    }
}
