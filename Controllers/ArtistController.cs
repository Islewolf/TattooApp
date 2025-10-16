using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TattooApp.Models;

namespace TattooApp.Controllers
{
    public class ArtistController : Controller
    {
        private DataContext context;

        public ArtistController(DataContext data)
        {
            context = data;
        }

        public IActionResult Index()
        {
            return View(context.Artists
                .Include(a => a.Specialties)
                .Include(a => a.Appointments));
        }

        public IActionResult Details(long id)
        {
            Artist? artist = context.Artists
                .Include(a => a.Specialties)
                .Include(a => a.Appointments)
                .Include(a => a.Binders)
                .FirstOrDefault(a => a.ArtistId == id);
                
            if (artist == null)
            {
                return NotFound();
            }
            
            return View(artist);
        }

        public IActionResult Create()
        {
            ViewBag.Specialties = context.Specialties.ToList();
            return View(new Artist());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Artist artist, [FromForm] long[] specialtyIds)
        {
            if (ModelState.IsValid)
            {
                artist.ArtistId = default;
                
                if (specialtyIds != null && specialtyIds.Length > 0)
                {
                    var specialties = context.Specialties
                        .Where(s => specialtyIds.Contains(s.SpecialtyId))
                        .ToList();
                    artist.Specialties = specialties;
                }
                
                context.Artists.Add(artist);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Specialties = context.Specialties.ToList();
            return View(artist);
        }

        public IActionResult Edit(long id)
        {
            Artist? artist = context.Artists
                .Include(a => a.Specialties)
                .FirstOrDefault(a => a.ArtistId == id);
                
            if (artist == null)
            {
                return NotFound();
            }
            
            ViewBag.Specialties = context.Specialties.ToList();
            ViewBag.SelectedSpecialties = artist.Specialties.Select(s => s.SpecialtyId).ToList();
            return View(artist);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Artist artist, [FromForm] long[] specialtyIds)
        {
            if (ModelState.IsValid)
            {
                var existingArtist = context.Artists
                    .Include(a => a.Specialties)
                    .FirstOrDefault(a => a.ArtistId == artist.ArtistId);
                    
                if (existingArtist != null)
                {
                    existingArtist.Name = artist.Name;
                    existingArtist.Email = artist.Email;
                    existingArtist.Phone = artist.Phone;
                    existingArtist.Role = artist.Role;
                    
                    existingArtist.Specialties.Clear();
                    if (specialtyIds != null && specialtyIds.Length > 0)
                    {
                        var specialties = context.Specialties
                            .Where(s => specialtyIds.Contains(s.SpecialtyId))
                            .ToList();
                        foreach (var specialty in specialties)
                        {
                            existingArtist.Specialties.Add(specialty);
                        }
                    }
                    
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            
            ViewBag.Specialties = context.Specialties.ToList();
            ViewBag.SelectedSpecialties = specialtyIds?.ToList() ?? new List<long>();
            return View(artist);
        }

        public IActionResult Delete(long id)
        {
            Artist? artist = context.Artists
                .Include(a => a.Appointments)
                .FirstOrDefault(a => a.ArtistId == id);
                
            if (artist == null)
            {
                return NotFound();
            }
            
            return View(artist);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            Artist? artist = context.Artists.Find(id);
            if (artist != null)
            {
                context.Artists.Remove(artist);
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

