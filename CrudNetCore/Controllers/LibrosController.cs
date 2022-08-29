using CrudNetCore.Entities;
using CrudNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudNetCore.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Libro> listLibros = context.Libro;

            return View(listLibros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                context.Libro.Add(libro);
                context.SaveChanges();

                TempData["mensaje"] = "El libro se ha creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                context.Libro.Update(libro);
                context.SaveChanges();

                TempData["mensaje"] = "El libro se ha actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {
            //Obtenemos el libro por Id
            var libro = context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            context.Libro.Remove(libro);
            context.SaveChanges();

            TempData["mensaje"] = "El libro se ha eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
