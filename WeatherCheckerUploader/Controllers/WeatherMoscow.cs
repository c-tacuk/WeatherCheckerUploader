using Microsoft.AspNetCore.Mvc;
using WeatherAppDatabase;
using WeatherAppDatabase.Models;
using WeatherCheckerUploader.Models;

namespace WeatherCheckerUploader.Controllers
{
    public class WeatherMoscow : Controller
    {
        private readonly IDbExelMethods exelMethods;
        public WeatherMoscow(IDbExelMethods exelMethods)
        {
            this.exelMethods = exelMethods;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WatchWeather()
        {
            return View();
        }
        public IActionResult ForYears()
        {
            return View();
        }
        public IActionResult ForMonths()
        {
            return View();
        }
        public IActionResult WatchYear(string year)
        {
            string path = "WeatherArchives/moskva_" + year + ".xlsx";
            var weatherArchive = new DbWeatherArchiveModel();
            exelMethods.SetAllData(weatherArchive);
            return View(weatherArchive);
        }
    }
}
