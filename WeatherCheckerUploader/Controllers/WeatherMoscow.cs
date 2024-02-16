using Microsoft.AspNetCore.Mvc;
using WeatherCheckerUploader.Models;
using WeatherCheckerUploader.WorkWithExel;

namespace WeatherCheckerUploader.Controllers
{
    public class WeatherMoscow : Controller
    {
        private readonly ExelMethods exelMethods = new ExelMethods();
        public IActionResult Index()
        {
            var weatherArchive = new WeatherArchiveModel();
            exelMethods.SetAllData(weatherArchive);
            return View(weatherArchive);
        }
    }
}
