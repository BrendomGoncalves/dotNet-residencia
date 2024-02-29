using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var mvcStudioContext = _context.Studio
                .Include(m => m.Movies).ToListAsync();
            return View(await mvcStudioContext);
        }

        // GET: Studios/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var studio = await _context.Studio
                  .Include(m => m.Movies)
                  .FirstOrDefaultAsync(m => m.StudioId == id);
            if (studio == null) return NotFound();

            return View(studio);
        }

        // GET: Studios/Create
        [Authorize(Policy = "Administrator")]
        public IActionResult Create()
        {
            ViewData["Movies"] = new SelectList(_context.Movie, "MovieId", "Title");
            return View();
        }

        // POST: Studios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Create([Bind("StudioId,Name,Country,Site")] Studio studio, List<int> movies)
        {
            if (ModelState.IsValid)
            {
                var _movies = _context.Movie
                    .Where(m => movies.Contains(m.MovieId))
                    .Include(s => s.Studio)
                    .ToList();
                
                if (_movies.Count > 0) studio.Movies = _movies;
                
                foreach (var item in _movies)
                {
                    if (item.Studio != null && !item.Studio.Equals(studio)) item.Studio = studio;
                }
                
                _context.Add(studio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), TempData["SuccessMessage"]);
            }

            ViewData["Movies"] = new SelectList(_context.Movie, "MovieId", "Title");

            return View(studio);
        }

        // GET: Studios/Edit/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var studio = await _context.Studio
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(m => m.StudioId == id);

            if (studio == null) return NotFound();

            ViewBag.Movies = _context.Movie.Select(m => new SelectListItem
            {
                Value = m.MovieId.ToString(),
                Text = m.Title
            }).ToList();

            return View(studio);
        }

        // POST: Studios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("StudioId,Name,Country,Site")] Studio studio,
            List<int> movies)
        {
            if (id != studio.StudioId) return NotFound();

            if (ModelState.IsValid)
            {
                var _movies = _context.Movie.Where(a => movies.Contains(a.MovieId)).ToList();
                if (_movies.Count > 0) studio.Movies = _movies;
                try
                {
                    _context.Update(studio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudioExists(studio.StudioId)) return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Movies = _context.Movie.Select(m => new SelectListItem
            {
                Value = m.MovieId.ToString(),
                Text = m.Title
            }).ToList();

            return View(studio);
        }

        // GET: Studios/Delete/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var studio = await _context.Studio
                   .Include(m => m.Movies)
                   .FirstOrDefaultAsync(m => m.StudioId == id);
            if (studio == null) return NotFound();

            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studio = await _context.Studio.FindAsync(id);
            if (studio != null) _context.Studio.Remove(studio);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudioExists(int id)
        {
            return (_context.Studio?.Any(e => e.StudioId == id)).GetValueOrDefault();
        }
    }
}