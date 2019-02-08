using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCX.Contexto;
using SCX.Models;

namespace SCX.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly DbContexto CatContexto;

        public CategoriaController(DbContexto _contexto)
        {
            CatContexto = _contexto;
        }

        [HttpGet]
        public IActionResult Categoria()
        {
            var categoria = new Categoria();
            return View(categoria);
        }


        [HttpGet]
        public IActionResult ListCategorias()
        {
            var categorias = CatContexto.Categorias.ToList();
            return View(categorias);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Categoria(Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                CatContexto.Categorias.Add(categoria);
                CatContexto.SaveChanges();
                return RedirectToAction("ListCategorias");
            }

            return View(categoria);
        }
        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Categoria categoria = CatContexto.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long? id, Categoria categoria)
        {
            var _categoria = CatContexto.Categorias.Find(id);
            _categoria.Nome = categoria.Nome;

            if (ModelState.IsValid)
            {
                CatContexto.Categorias.Update(_categoria);
                CatContexto.SaveChanges();
                return RedirectToAction("ListCategorias");
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Delete(long? id)
        {

            Categoria categoria = CatContexto.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long? id)
        {

            Categoria categoria = CatContexto.Categorias.Find(id);

            if (categoria != null)
            {
                CatContexto.Categorias.Remove(categoria);
                CatContexto.SaveChanges();
                return RedirectToAction("ListCategorias");
            }


            return View(categoria);


        }

    }
}