using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherCheckerUploader.Controllers
{
    public class ArchiveUpload : Controller
    {
        // GET: ArchiveUpload
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArchiveUpload/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArchiveUpload/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArchiveUpload/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArchiveUpload/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArchiveUpload/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArchiveUpload/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArchiveUpload/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
