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
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ProductoViewModel> lst = new List<ProductoViewModel>();

            using (FacturaAppBdContext db = new FacturaAppBdContext())
            {
                lst = (from d in db.Productos
                       join c in db.Categorias  on d.CategoriaId equals c.CategoriaId
                       select new ProductoViewModel
                       {
                           ID = d.ProductoId,
                           Nombre = d.Nombre,
                           Descripcion = d.Descripcion,
                           PrecioVenta = d.PrecioVenta,
                           NombreCategoria = c.Descripción
                       }).ToList();
            }
            return View(lst);
            
        }

        public ActionResult New()
        {
            //Mandamos a la vista el DropDownList
            List<CategoriaViewModel> lst = null;
            using (FacturaAppBdContext db = new FacturaAppBdContext())
            {
                 lst =
                    (
                      from d in db.Categorias
                      select new CategoriaViewModel
                      {
                          ID = d.CategoriaId,
                          Descripcion = d.Descripción

                      }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Descripcion.ToString(),
                    Value = d.ID.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = items; //Mandamos a la Vista
            return View();
        }

        [HttpPost]
        public ActionResult Save(ProductoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    var oProducto = new Productos();
                    oProducto.Nombre = model.Nombre;
                    oProducto.Descripcion = model.Descripcion;
                    oProducto.PrecioVenta = model.PrecioVenta;
                    oProducto.CategoriaId = model.CategoriaId;
                    db.Productos.Add(oProducto);
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

            try
            {
                //Mandamos a la vista el DropDownList
                List<CategoriaViewModel> lst = null;
                using (FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    lst =
                       (
                         from d in db.Categorias
                         select new CategoriaViewModel
                         {
                             ID = d.CategoriaId,
                             Descripcion = d.Descripción

                         }).ToList();
                }

                List<SelectListItem> items = lst.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Descripcion.ToString(),
                        Value = d.ID.ToString(),
                        Selected = false
                    };
                });
                ViewBag.items = items; //Mandamos a la Vista

                ProductoViewModel model = new ProductoViewModel();

                using (FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    var oProducto = db.Productos.Find(Id);
                    model.Nombre = oProducto.Nombre;
                    model.Descripcion = oProducto.Descripcion;
                    model.PrecioVenta = oProducto.PrecioVenta;
                    model.CategoriaId = oProducto.CategoriaId;
                    model.ID = oProducto.ProductoId;
                }
                return View(model);


            }
            catch (Exception ex)
            {
                return View(ex.Message);
                throw;
            }
            
        }

        //Actualiza el registro
        [HttpPost]
        public ActionResult Update(ProductoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    var oProducto = db.Productos.Find(model.ID);
                    oProducto.Nombre = model.Nombre;
                    oProducto.Descripcion = model.Descripcion;
                    oProducto.PrecioVenta = model.PrecioVenta;
                    oProducto.CategoriaId = model.CategoriaId;
                    db.Entry(oProducto).State = EntityState.Modified;
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
                    var oProducto = db.Productos.Find(ID);
                    db.Productos.Remove(oProducto);
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