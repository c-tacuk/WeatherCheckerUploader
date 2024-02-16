using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherCheckerUploader.Controllers
{
    public class WeatherMoscow : Controller
    {
        // GET: WeatherMoscow
        public ActionResult Index()
        {
            return View();
        }

        // GET: WeatherMoscow/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeatherMoscow/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatherMoscow/Create
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

        // GET: WeatherMoscow/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeatherMoscow/Edit/5
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

        // GET: WeatherMoscow/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeatherMoscow/Delete/5
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
