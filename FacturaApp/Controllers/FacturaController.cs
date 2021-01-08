using FacturaApp.Models;
using FacturaApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacturaApp.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura

        public ActionResult Index()
        {


            /*List<Productos> ListaProductos = db.Productos.ToList();
            ViewBag.ProductosLista = new SelectList(ListaProductos, "ProductoId", "Nombre", "PrecioVenta");
            */
            return View();
        }
        [HttpGet]
        public ActionResult Registrar()
        {
            using (FacturaAppBdContext db = new FacturaAppBdContext())
            {
                List<Clientes> ListaCliente = db.Clientes.ToList();
                ViewBag.ClienteLista = new SelectList(ListaCliente, "ClienteId", "Nombre");

                return View();
            }
        }

        [HttpGet]
        public ActionResult BuscarProducto()
        {
            using (FacturaAppBdContext db = new FacturaAppBdContext())
            {
                return Json(db.Productos.Select(x => new
                {
                    ProductoId = x.ProductoId,
                    Nombre = x.Nombre,
                    PrecioVenta = x.PrecioVenta

                }).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult BuscarCliente()
        {
            using (FacturaAppBdContext db = new FacturaAppBdContext())
            {
                return Json(db.Clientes.Select(x => new
                {
                    ClienteId = x.ClienteId,
                    NombreCompleto = x.Nombre + " " + x.Apellido
                   
                }).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Registrar(FacturaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
               
                using (FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    Factura oFactura = new Factura();
                    oFactura.ClienteId = model.ClienteId;
                    oFactura.Fecha = DateTime.Now;
                    db.Facturas.Add(oFactura);
                    db.SaveChanges();

                    foreach (var item in model.DetalleFacturaViewModels)
                    {
                        DetalleFactura oDetalleFactura = new DetalleFactura();
                        oDetalleFactura.ProductoId = item.ProductoId;
                        oDetalleFactura.Cantidad = item.Cantidad;
                        oDetalleFactura.Total = item.Precio * item.Cantidad;
                        oDetalleFactura.FacturaId = oFactura.FacturaId;
                        db.DetalleFacturas.Add(oDetalleFactura);
                    }

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
                throw;
            }

           
        }

       
    }
}