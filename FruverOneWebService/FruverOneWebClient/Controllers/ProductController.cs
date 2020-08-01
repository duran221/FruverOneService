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
           
            return View("Product", miLista);
        }

        public ActionResult Verduras()
        {

            return View("Product");
        }
        public ActionResult Estrella()
        {

            return View("Product");
        }
    }
}