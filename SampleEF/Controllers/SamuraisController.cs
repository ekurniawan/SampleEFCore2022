using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleEF.Data.Dal;

namespace SampleEF.Controllers
{
    public class SamuraisController : Controller
    {
        private readonly ISamurai _samurai;
        public SamuraisController(ISamurai samurai)
        {
            _samurai = samurai;
        }

        // GET: SamuraisController
        public async Task<ActionResult> Index()
        {
            var model = await _samurai.GetAll();
            return View(model);
        }

        // GET: SamuraisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SamuraisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SamuraisController/Create
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

        // GET: SamuraisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SamuraisController/Edit/5
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

        // GET: SamuraisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SamuraisController/Delete/5
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
