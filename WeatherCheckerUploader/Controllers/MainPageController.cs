using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Diagnostics;
using WeatherCheckerUploader.Models;
using WeatherCheckerUploader.WorkWithExel;

namespace WeatherCheckerUploader.Controllers
{
    public class MainPageController : Controller
    {
        private readonly ILogger<MainPageController> _logger;
        private readonly ExelMethods exelMethods = new ExelMethods();

        public MainPageController(ILogger<MainPageController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var elems = exelMethods.GetRowData(3);
            //Console.WriteLine(exelMethods.GetArchiveHeader());
            //foreach (string el in elems)
            //{
            //    Console.WriteLine(el);
            //}
            var elems = exelMethods.GetColumnNames();
            foreach (string el in elems)
            {
                Console.WriteLine(el);
            }
            return View();
        }
    }
}