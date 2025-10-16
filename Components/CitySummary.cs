using Microsoft.AspNetCore.Mvc;
using TattooApp.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;

namespace TattooApp.Components {

    public class CitySummary : ViewComponent {
        private CitiesData data;

        public CitySummary(CitiesData cdata) {
            data = cdata;
        }

        public IViewComponentResult Invoke(string themeName="success") {
            ViewBag.Theme = themeName;
            return View(new CityViewModel {
                Cities = data.Cities.Count(),
                Population = data.Cities.Sum(c => c.Population)
            });
        }
    }
}
