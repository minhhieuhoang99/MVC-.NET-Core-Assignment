
using Microsoft.AspNetCore.Mvc;

using MVC_2.Models;

namespace MVC_2.Controllers
{
    public class RookiesController : Controller
    {

        private readonly Service _service;
        public RookiesController(Service service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.Get());
        }

        public IActionResult Details(int id)
        {
            var b = _service.Get(id);
            if (b == null) return NotFound();
            else return View(b);
        }

        public IActionResult Delete(int id)
        {
            var b = _service.Get(id);
            if (b == null) return NotFound();
            else return View(b);
        }

        [HttpPost]
        public IActionResult Delete(PersonModel person)
        {
            _service.Delete(person.id);
            _service.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var b = _service.Get(id);
            if (b == null) return NotFound();
            else return View(b);
        }

        [HttpPost]
        public IActionResult Edit(PersonModel person)
        {

            _service.Update(person);
            _service.SaveChanges();
            return View(person);
        }

        public IActionResult Create() => base.View(_service.Create());

        [HttpPost]
        public IActionResult Create(PersonModel person)
        {


            _service.Add(person);
            _service.SaveChanges();
            return View(person);
        }



    }
}