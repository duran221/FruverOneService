using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Business.Control;
using System.Security.Permissions;

namespace APIFruverOne.Controllers
{
    public class RegistrarProductoController : Controller
    {
        private readonly ControlRegistrarProducto controlRegistro;
        

        public  RegistrarProductoController()
        {
            controlRegistro = new ControlRegistrarProducto();
        }
        // GET: RegistrarProducto
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistrarProducto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrarProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrarProducto/Create
        [HttpPost]
        public bool Post(JObject producto)
        {
            return controlRegistro.RegistrarProducto(producto);
        }

        // GET: RegistrarProducto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrarProducto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrarProducto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrarProducto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
