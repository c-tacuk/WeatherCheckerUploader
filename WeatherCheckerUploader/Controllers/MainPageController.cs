using Microsoft.AspNetCore.Mvc;

namespace WeatherCheckerUploader.Controllers
{
    public class MainPageController : Controller
    {
        private readonly ILogger<MainPageController> _logger;

        public MainPageController(ILogger<MainPageController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}