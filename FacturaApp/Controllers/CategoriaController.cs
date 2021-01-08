using FacturaApp.Models;
using FacturaApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturaApp.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            List<CategoriaViewModel> lst = new List<CategoriaViewModel>();

            using (FacturaAppBdContext db = new FacturaAppBdContext())
            {
                lst = (from d in db.Categorias
                       select new CategoriaViewModel
                       {
                           ID = d.CategoriaId,
                           Descripcion = d.Descripción
                       }).ToList();
            }
            return View(lst);
        }


        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(CategoriaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using(FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    var oCategoria = new Categorias();
                    oCategoria.Descripción = model.Descripcion;
                    db.Categorias.Add(oCategoria);
                    db.SaveChanges();

                }
                    return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
                throw;
            }
            
        }

        //vista para poder Editar y traer los datos
        public ActionResult Edit(int Id)
        {
            CategoriaViewModel model = new CategoriaViewModel();

            using (FacturaAppBdContext db = new FacturaAppBdContext())
            {
                var oCategoria = db.Categorias.Find(Id);
                model.Descripcion = oCategoria.Descripción;
                model.ID = oCategoria.CategoriaId;
            }

            return View(model);
        }

        //Actualiza el registro
        [HttpPost]
        public ActionResult Update(CategoriaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    var oCategoria = db.Categorias.Find(model.ID);
                    oCategoria.Descripción = model.Descripcion;
                    db.Entry(oCategoria).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);

            }

        }

        //Elimiar el registro
        [HttpPost]
        public ActionResult Detele(int ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    var oCategoria = db.Categorias.Find(ID);
                    db.Categorias.Remove(oCategoria);
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);

            }
        }
    }
}
