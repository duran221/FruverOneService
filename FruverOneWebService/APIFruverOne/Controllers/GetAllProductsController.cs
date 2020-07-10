using Business.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Class;

namespace APIFruverOne.Controllers
{
    public class GetAllProductsController : ApiController
    {
        // GET: api/GetAllProducts
        public List<String> Get()
        {
            ControlGetProducts getProducts = new ControlGetProducts();
            List<Producto> products = getProducts.GetProducts();

            List<String> temp = new List<String>();
            temp.Add("LOko");
            temp.Add(products.Count.ToString());


            foreach (Producto p in products)
            {
                temp.Add(p.nombreProducto);
            }
            
            return temp;
        }

        // GET: api/GetAllProducts/5
        public string Get(int id)
        {
            


            return "no hay ID";
        }

        // POST: api/GetAllProducts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetAllProducts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetAllProducts/5
        public void Delete(int id)
        {
        }
    }
}
