using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ArtistController : Controller
    {
        private readonly MvcMovieContext _context;

        public ArtistController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Artist
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var mvcArtistContext = _context.Artist
                .Include(m => m.Movies)
                .ToListAsync();
            return View(await mvcArtistContext);
        }

        // GET: Artist/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var artist = await _context.Artist
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null) return NotFound();

            return View(artist);
        }

        // GET: Artist/Create
        [Authorize(Policy = "Administrator")]
        public IActionResult Create()
        {
            ViewData["Movies"] = new SelectList(_context.Movie, "MovieId", "Title");
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Create([Bind("ArtistId,Name,Bio,Site")] Artist artist, List<int> movies)
        {
            if (ModelState.IsValid)
            {
                var _movies = _context.Movie
                    .Where(m => movies.Contains(m.MovieId))
                    .Include(movie => movie.Artists)
                    .ToList();
                
                if (_movies.Count > 0) artist.Movies = _movies;
                
                foreach (var item in _movies)
                {
                    if (item.Artists != null && !item.Artists.Contains(artist)) item.Artists?.Add(artist);
                }
                
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Movies"] = new SelectList(_context.Movie, "MovieId", "Title");
            
            return View(artist);
        }

        // GET: Artist/Edit/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var artist = await _context.Artist
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(a => a.ArtistId == id);
            
            if (artist == null) return NotFound();

            ViewData["Movies"] =
                new SelectList(_context.Movie, "MovieId", "Title", artist.Movies!.Select(a => a.MovieId));

            return View(artist);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,Name,Bio,Site")] Artist artist, List<int> movies)
        {
            if (id != artist.ArtistId) return NotFound();

            if (ModelState.IsValid)
            {
                var _movies = _context.Movie.Where(a => movies.Contains(a.MovieId)).ToList();
                if (_movies.Count > 0)
                {
                    var existingArtist = await _context.Artist
                        .Include(m => m.Movies)
                        .FirstOrDefaultAsync(m => m.ArtistId == artist.ArtistId);

                    if (existingArtist != null)
                    {
                        existingArtist.Movies?.Clear();
                        await _context.SaveChangesAsync();

                        existingArtist.Name = artist.Name;
                        existingArtist.Bio = artist.Bio;
                        existingArtist.Site = artist.Site;
                        existingArtist.Movies = _movies;

                        foreach (var item in _movies)
                        {
                            item.Artists?.Add(existingArtist);
                        }
                    }

                    try
                    {
                        if (existingArtist != null) _context.Update(artist);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ArtistExists(artist.ArtistId)) return NotFound();
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Movies"] = new SelectList(_context.Movie, "MovieId", "Title", artist.Movies!.Select(m => m.MovieId));
            
            return View(artist);
        }

        // GET: Artist/Delete/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var artist = await _context.Artist
                .Include(m => m.Movies)
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null) return NotFound();

            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artist.FindAsync(id);
            if (artist != null) _context.Artist.Remove(artist);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
            return (_context.Artist?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
}