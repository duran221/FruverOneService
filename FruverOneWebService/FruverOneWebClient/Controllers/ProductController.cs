using FruverOneWebClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FruverOneWebClient.Controllers
{
    [Authorize]
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

            ProdutView searchProduct = new ProdutView();
            String m = searchProduct.GetHttpProduct(nameProduct);
            dynamic data = JsonConvert.DeserializeObject(m);

            if (data.message == 200)
            {

                ViewBag.COD = data.COD;
                ViewBag.Message = data.Name;
                ViewBag.Image_url = data.Image_url;
                ViewBag.Category = data.NameCategory;
                ViewBag.Name = data.Name;
                ViewBag.Description = data.Description;
                ViewBag.Price = data.Price;
                ViewBag.Desc = data.Discount;
                ViewBag.busqueda = true;
            }
            else {

                ViewBag.busqueda = false;

            }
           
            return View("ViewProduct");
        }

    }
}