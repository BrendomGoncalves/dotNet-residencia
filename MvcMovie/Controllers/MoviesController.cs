using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Movie
                .Include(m => m.Studio)
                .Include(m => m.Artists);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Movies/Details/5
        [Authorize(Policy = "Administrator")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _context.Movie
                .Include(m => m.Studio)
                .Include(m => m.Artists)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null) return NotFound();

            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Policy = "Administrator")]
        public IActionResult Create()
        {
            ViewData["Studios"] = new SelectList(_context.Studio, "StudioId", "Name");
            ViewData["Artists"] = new SelectList(_context.Artist, "ArtistId", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Create([Bind("MovieId,Title,ReleaseDate,Genre,Price,StudioId")] Movie movie, List<int> artists)
        {
            if (ModelState.IsValid)
            {
                var _studio = await _context.Studio.FirstOrDefaultAsync(m => m.StudioId == movie.StudioId);
                if (_studio != null)
                {
                    var _artists = _context.Artist.Where(a => artists.Contains(a.ArtistId)).ToList();
                    if (_artists.Count > 0) movie.Artists = _artists;
                    movie.Studio = _studio;
                    _context.Add(movie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["StudioId"] = new SelectList(_context.Set<Studio>(), "StudioId", "Name");
            ViewData["Artists"] = new SelectList(_context.Set<Artist>(), "ArtistId", "Name");
            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _context.Movie
                .Include(m => m.Studio)
                .Include(m => m.Artists)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null) return NotFound();

            ViewData["StudioId"] = new SelectList(_context.Studio, "StudioId", "Name", movie.StudioId);
            ViewData["Artists"] =
                new SelectList(_context.Artist, "ArtistId", "Name", movie.Artists!.Select(a => a.ArtistId));
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Title,ReleaseDate,Genre,Price,StudioId")] Movie movie, List<int> artists)
        {
            if (id != movie.MovieId) return NotFound();

            if (ModelState.IsValid)
            {
                var _studio = await _context.Studio.FirstOrDefaultAsync(m => m.StudioId == movie.StudioId);
                if (_studio != null)
                {
                    var _artists = _context.Artist.Where(a => artists.Contains(a.ArtistId)).ToList();
                    if (_artists.Count > 0) movie.Artists = _artists;
                    movie.Studio = _studio;
                }
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["StudioId"] = new SelectList(_context.Studio, "StudioId", "StudioId", movie.StudioId);
            ViewData["Artists"] =
                new SelectList(_context.Artist, "ArtistId", "Name", movie.Artists!.Select(a => a.ArtistId));
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _context.Movie
                .Include(m => m.Studio)
                .Include(m => m.Artists)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie != null) _context.Movie.Remove(movie);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return (_context.Movie?.Any(e => e.MovieId == id)).GetValueOrDefault();
        }
    }
}