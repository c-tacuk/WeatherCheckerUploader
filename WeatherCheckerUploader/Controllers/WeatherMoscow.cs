using Microsoft.AspNetCore.Mvc;

namespace WeatherCheckerUploader.Controllers
{
    public class WeatherMoscow : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
