using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WeatherCheckerUploader.Models;
using WeatherCheckerUploader.WorkWithExel;

namespace WeatherCheckerUploader.Controllers
{
    public class WeatherMoscow : Controller
    {
        private readonly IExelMethods exelMethods;
        public WeatherMoscow(IExelMethods exelMethods)
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
            var weatherArchive = new WeatherArchiveModel();
            exelMethods.SetAllData(weatherArchive);
            return View(weatherArchive);
        }
    }
}
