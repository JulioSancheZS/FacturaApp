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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteViewModel> lst = new List<ClienteViewModel>();

            using (FacturaAppBdContext db = new FacturaAppBdContext())
            {
                lst = (from d in db.Clientes
                       select new ClienteViewModel
                       {
                           ID = d.ClienteId,
                           Nombre = d.Nombre,
                           Apellido = d.Apellido,
                           Edad = d.Edad,
                           Direccion = d.Direccion,
                           Telefono = d.Telefono
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(ClienteViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    var oCliente = new Clientes();
                    oCliente.Nombre = model.Nombre;
                    oCliente.Apellido = model.Apellido;
                    oCliente.Edad = model.Edad;
                    oCliente.Direccion = model.Direccion;
                    oCliente.Telefono = model.Telefono;
                    db.Clientes.Add(oCliente);
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
            ClienteViewModel model = new ClienteViewModel();

            using (FacturaAppBdContext db = new FacturaAppBdContext())
            {
                var oCliente = db.Clientes.Find(Id);
                model.Nombre = oCliente.Nombre;
                model.Apellido = oCliente.Apellido;
                model.Edad = oCliente.Edad;
                model.Direccion = oCliente.Direccion;
                model.Telefono = oCliente.Telefono;
                model.ID = oCliente.ClienteId;
            }

            return View(model);
        }

        //Actualiza el registro
        [HttpPost]
        public ActionResult Update(ClienteViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (FacturaAppBdContext db = new FacturaAppBdContext())
                {
                    var oCliente = db.Clientes.Find(model.ID);
                    oCliente.Nombre = model.Nombre;
                    oCliente.Apellido = model.Apellido;
                    oCliente.Edad = model.Edad;
                    oCliente.Direccion = model.Direccion;
                    oCliente.Telefono = model.Telefono;
                    db.Entry(oCliente).State = EntityState.Modified;
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
                    var oCliente = db.Clientes.Find(ID);
                    db.Clientes.Remove(oCliente);
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