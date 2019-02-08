using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SCX.Contexto;
using SCX.Models;

namespace SCX.Controllers
{
 public class SubCategoriaController : Controller
    {
        private readonly DbContexto SubCatContexto;

        public SubCategoriaController(DbContexto _contexto)
        {
            SubCatContexto = _contexto;
        }

        [HttpGet]
        public IActionResult SubCategoria()
        {
            var subcategoria = new SubCategoria();
            return View(subcategoria);
        }


        [HttpGet]
        public IActionResult ListSubCategorias()
        {
            var subcategorias = SubCatContexto.SubCategorias.ToList();
            return View(subcategorias);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubCategoria(SubCategoria subcategoria)
        {

            if (ModelState.IsValid)
            {
                SubCatContexto.SubCategorias.Add(subcategoria);
                SubCatContexto.SaveChanges();
                return RedirectToAction("ListSubCategorias");
            }

            return View(subcategoria);
        }
        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SubCategoria subcategoria = SubCatContexto.SubCategorias.Find(id);

            if (subcategoria == null)
            {
                return NotFound();
            }
            return View(subcategoria);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long? id, Categoria categoria)
        {
            var _categoria = SubCatContexto.SubCategorias.Find(id);
            _categoria.Nome = categoria.Nome;

            if (ModelState.IsValid)
            {
                SubCatContexto.SubCategorias.Update(_categoria);
                SubCatContexto.SaveChanges();
                return RedirectToAction("ListSubCategorias");
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Delete(long? id)
        {

            SubCategoria subcategoria = SubCatContexto.SubCategorias.Find(id);

            if (subcategoria == null)
            {
                return NotFound();
            }

            return View(subcategoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long? id)
        {

            SubCategoria subcategoria = SubCatContexto.SubCategorias.Find(id);

            if (subcategoria != null)
            {
                SubCatContexto.SubCategorias.Remove(subcategoria);
                SubCatContexto.SaveChanges();
                return RedirectToAction("ListSubCategorias");
            }


            return View(subcategoria);


        }

    }
}