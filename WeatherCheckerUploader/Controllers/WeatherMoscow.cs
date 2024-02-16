using Microsoft.AspNetCore.Mvc;
using WeatherCheckerUploader.Models;
using WeatherCheckerUploader.WorkWithExel;

namespace WeatherCheckerUploader.Controllers
{
    public class WeatherMoscow : Controller
    {
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
            var weatherArchive = new WeatherArchiveModel();
            var exelMethods = new ExelMethods(path);
            exelMethods.SetAllData(weatherArchive);
            return View(weatherArchive);
        }
    }
}
