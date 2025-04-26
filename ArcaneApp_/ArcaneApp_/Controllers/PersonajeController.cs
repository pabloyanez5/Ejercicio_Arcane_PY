using ArcaneApp_.Models;
using Microsoft.AspNetCore.Mvc;
using ArcaneApp_.Models;

namespace ArcaneApp_.Controllers
{
    public class PersonajeController : Controller
    {
        static List<Personaje> personajes = new();

        public IActionResult Index()
        {
            return View(personajes);
        }

        [HttpPost]
        public IActionResult Crear(Personaje p)
        {
            personajes.Add(p);
            return RedirectToAction("Index");
        }
    }
}
