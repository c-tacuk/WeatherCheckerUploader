using Microsoft.AspNetCore.Mvc;
using WeatherCheckerUploader.Models;

namespace WeatherCheckerUploader.Controllers
{
    public class ArchiveUpload : Controller
    {
        IWebHostEnvironment _appEnvironment;
        public ArchiveUpload(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
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
                using (var fileStream = new FileStream(_appEnvironment.ContentRootPath + path, FileMode.Create)) // сохраняем файл в папку WeatherArchives
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                var file = new WeatherArchiveModel { Name = uploadedFile.FileName };
            }
            return RedirectToAction("Index");
        }
    }
}
