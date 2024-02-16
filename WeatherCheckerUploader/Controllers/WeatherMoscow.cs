using Microsoft.AspNetCore.Mvc;
using WeatherCheckerUploader.Db;
using WeatherCheckerUploader.Models;

namespace WeatherCheckerUploader.Controllers
{
    public class WeatherMoscow : Controller
    {
        private readonly DbExelMethods exelMethods = new DbExelMethods("WeatherArchives/moskva_2010.xlsx");
        public IActionResult Index()
        {
            var weatherArchive = new WeatherArchiveModel();
            exelMethods.SetAllData(weatherArchive);
            return View(weatherArchive);
        }
    }
}
