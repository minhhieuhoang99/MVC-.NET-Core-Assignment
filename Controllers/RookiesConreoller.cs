
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC_2.Models;
using MVC_2.Services;

namespace MVC_2.Controllers
{
    public class RookiesController : Controller
    {

        private readonly IService _service;
        public RookiesController(IService service){
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
            var a = this.HttpContext.Session.GetString("person");    
            HttpContext.Session.SetString("person", $"{person.id}");  
            TempData["personDelete"] = $"Person {person.id} was removed from the list successfully! ";
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
            if (ModelState.IsValid) 
            {
                _service.Add(person);
                _service.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(person);
        }

    }
}