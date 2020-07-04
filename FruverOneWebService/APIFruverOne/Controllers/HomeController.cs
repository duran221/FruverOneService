using APIFruverOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIFruverOne.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ListaProductos miLista  = new ListaProductos();
          //  List<Producto> resp = miLista.productos;

            return View(miLista);
        }
    }
}