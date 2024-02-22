using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WeatherAppDatabase;
using WeatherCheckerUploader.Models;

namespace WeatherCheckerUploader.Controllers
{
    public class ArchiveUpload : Controller
    {
        IWebHostEnvironment appEnvironment;
        IDbExelMethods exelMethods;
        public ArchiveUpload(IWebHostEnvironment appEnvironment, IDbExelMethods exelMethods)
        {
            this.appEnvironment = appEnvironment;
            this.exelMethods = exelMethods;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/WeatherArchives/" + uploadedFile.FileName; // путь к папке WeatherArchives
                using (var fileStream = new FileStream(appEnvironment.ContentRootPath + path, FileMode.Create)) // сохраняем файл в папку WeatherArchives
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                string сombinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), $"..\\WeatherCheckerUploader\\WeatherArchives\\{uploadedFile.FileName}");
                exelMethods.SetAllData(сombinedPath);
            }
            return RedirectToAction("Index");
        }
    }
}
