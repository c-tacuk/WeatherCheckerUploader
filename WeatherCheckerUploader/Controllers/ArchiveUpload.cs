using Microsoft.AspNetCore.Mvc;

namespace WeatherCheckerUploader.Controllers
{
    public class ArchiveUpload : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
