using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SCX.Contexto;
using SCX.Models;

namespace SCX.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaContexto CatContexto;

        public CategoriaController(CategoriaContexto _contexto)
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
            var categoria = CatContexto.Categorias.Find(id);

            if (categoria != null)
            {

                return View(categoria);
            }

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {



            if (ModelState.IsValid)
            {
                CatContexto.Categorias.Update(categoria);
                CatContexto.SaveChanges();

                return RedirectToAction("ListCategorias");

            }

            return View(categoria);
        }


           [HttpPost]
        public IActionResult Delete(Categoria _categoria)
        {
            var categoria = CatContexto.Categorias.Find(_categoria.IdCategoria);

            if (categoria!=null)
            {
                CatContexto.Categorias.Remove(categoria);
                CatContexto.SaveChanges();

                return RedirectToAction("ListCategorias");

            }

            return View();
        }

        
        [HttpGet]
        public IActionResult Delete(long? id)
        {
            var categoria = CatContexto.Categorias.Find(id);

            if (categoria != null)
            {

                return View(categoria);
            }

            return View(categoria);
        }










    }
}