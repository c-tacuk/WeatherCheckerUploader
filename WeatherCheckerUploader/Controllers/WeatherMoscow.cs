using Microsoft.AspNetCore.Mvc;
using WeatherAppDatabase;
using WeatherAppDatabase.Models;
using WeatherCheckerUploader.Models;

namespace WeatherCheckerUploader.Controllers
{
    public class WeatherMoscow : Controller
    {
        private readonly IDbExelMethods exelMethods;
        private readonly DatabaseContext databaseContext;
        public WeatherMoscow(IDbExelMethods exelMethods, DatabaseContext databaseContext)
        {
            this.exelMethods = exelMethods;
            this.databaseContext = databaseContext;
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
            var models = databaseContext.dbWeatherArchiveModels;
            var names = new List<string>();
            foreach(var model in models)
            {
                names.Add(model.Name);
            }
            return View(weatherArchive);
        }
    }
}
