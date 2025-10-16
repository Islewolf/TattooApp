using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TattooApp.Models;

namespace TattooApp.Controllers {

    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller {
        private DataContext context;

        public HomeController(DataContext data) {
            context = data;
        }

        public IActionResult Index() {
            var todayAppointments = context.Appointments
                .Include(a => a.Artist)
                .Where(a => a.AppointmentDate.Date == DateTime.Today)
                .OrderBy(a => a.AppointmentDate)
                .ToList();
                
            var upcomingAppointments = context.Appointments
                .Include(a => a.Artist)
                .Where(a => a.AppointmentDate.Date > DateTime.Today)
                .OrderBy(a => a.AppointmentDate)
                .Take(10)
                .ToList();
                
            ViewBag.TodayAppointments = todayAppointments;
            ViewBag.UpcomingAppointments = upcomingAppointments;
            ViewBag.ArtistCount = context.Artists.Count();
            ViewBag.TotalAppointments = context.Appointments.Count();
            
            return View();
        }
    }
}
