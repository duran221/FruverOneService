using FruverOneWebClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FruverOneWebClient.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Frutas() {
            ListProduct miLista = new ListProduct("FRUTA");
            ViewBag.nameList = "Listado de Frutas";
            return View("Product", miLista);
        }

        public ActionResult Verduras()
        {
            ListProduct miLista = new ListProduct("VEGETAL");
            ViewBag.nameList = "Listado de Vegetales";
            return View("Product", miLista);
         
        }
        public ActionResult Estrella()
        {
            ListProduct miLista = new ListProduct("STAR");
            ViewBag.nameList = "Productos Estrella";
            return View("Product", miLista);

        }
        public ActionResult viewProduct(string nameProduct) {

            ViewBag.Message = nameProduct;
            ViewBag.Image_url = "F0500.jpg";
            ViewBag.Category = "Frutas";
            ViewBag.Name = "Mango";
            ViewBag.Description = "Pulpa de mango";
            ViewBag.Price = 500;
            
            return View("ViewProduct");
        }

    }
}