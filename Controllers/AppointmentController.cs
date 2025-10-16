using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TattooApp.Models;

namespace TattooApp.Controllers
{
    public class AppointmentController : Controller
    {
        private DataContext context;

        public AppointmentController(DataContext data)
        {
            context = data;
        }

        public IActionResult Index()
        {
            return View(context.Appointments
                .Include(a => a.Artist)
                .OrderBy(a => a.AppointmentDate));
        }

        public IActionResult Details(long id)
        {
            Models.Appointment? appointment = context.Appointments
                .Include(a => a.Artist)
                .ThenInclude(a => a.Specialties)
                .FirstOrDefault(a => a.AppointmentId == id);
                
            if (appointment == null)
            {
                return NotFound();
            }
            
            return View(appointment);
        }

        public IActionResult Create()
        {
            ViewBag.Artists = context.Artists.ToList();
            return base.View(new Models.Appointment { AppointmentDate = DateTime.Now.AddDays(1) });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Models.Appointment appointment, string AppointmentTime)
        {
            // Combine date and time from separate inputs
            if (!string.IsNullOrEmpty(AppointmentTime))
            {
                var timeParts = AppointmentTime.Split(':');
                if (timeParts.Length == 2)
                {
                    appointment.AppointmentDate = appointment.AppointmentDate.Date
                        .AddHours(int.Parse(timeParts[0]))
                        .AddMinutes(int.Parse(timeParts[1]));
                }
            }
            
            // Remove Artist from validation since it's a navigation property
            ModelState.Remove("Artist");
            
            if (ModelState.IsValid)
            {
                appointment.AppointmentId = default;
                context.Appointments.Add(appointment);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Artists = context.Artists.ToList();
            return View(appointment);
        }

        public IActionResult Edit(long id)
        {
            Models.Appointment? appointment = context.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }
            
            ViewBag.Artists = context.Artists.ToList();
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Models.Appointment appointment, string AppointmentTime)
        {
            // Combine date and time from separate inputs
            if (!string.IsNullOrEmpty(AppointmentTime))
            {
                var timeParts = AppointmentTime.Split(':');
                if (timeParts.Length == 2)
                {
                    appointment.AppointmentDate = appointment.AppointmentDate.Date
                        .AddHours(int.Parse(timeParts[0]))
                        .AddMinutes(int.Parse(timeParts[1]));
                }
            }
            
            // Remove Artist from validation since it's a navigation property
            ModelState.Remove("Artist");
            
            if (ModelState.IsValid)
            {
                context.Appointments.Update(appointment);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Artists = context.Artists.ToList();
            return View(appointment);
        }

        public IActionResult Delete(long id)
        {
            Models.Appointment? appointment = context.Appointments
                .Include(a => a.Artist)
                .FirstOrDefault(a => a.AppointmentId == id);
                
            if (appointment == null)
            {
                return NotFound();
            }
            
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            Models.Appointment? appointment = context.Appointments.Find(id);
            if (appointment != null)
            {
                context.Appointments.Remove(appointment);
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

