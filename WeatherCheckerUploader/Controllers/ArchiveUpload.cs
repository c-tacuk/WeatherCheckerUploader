using Microsoft.AspNetCore.Mvc;
using WeatherCheckerUploader.Db;
using WeatherCheckerUploader.Models;

namespace WeatherCheckerUploader.Controllers
{
    public class ArchiveUpload : Controller
    {
        IWebHostEnvironment _appEnvironment;
        DbExelMethods _dbExelMethods;
        public ArchiveUpload(IWebHostEnvironment appEnvironment, DbExelMethods dbExelMethods)
        {
            _appEnvironment = appEnvironment;
            _dbExelMethods = dbExelMethods;
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
                
            }
            return RedirectToAction("Index");
        }
    }
}
