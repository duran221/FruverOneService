using Business.Control;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using System.Web.WebPages;

namespace APIFruverOne.Controllers
{
    public class GetProductController : ApiController
    {

        private ControlGetProduct product;
        /// <summary>
        /// Solicitud tipo GET para mostrar información de un producto en específico
        /// </summary>
        /// <param name="nameProduct"> nombre del producto al realizar la compra</param>
        /// <returns>JSON con información del producto</returns>
        // GET: api/GetProduct
        public IHttpActionResult GetProduct(string nameProduct)
        {
            if (!nameProduct.IsEmpty())
            {
                this.product = new ControlGetProduct();
                return Ok(this.product.getProduct((nameProduct.ToUpper()).Trim()));
            }
            else {

                String queryProd = @"{'message': 400}";
                JObject productJSON = JObject.Parse(queryProd);

                return Ok(productJSON);
            
            }

        }
        /// <summary>
        /// Nombres de Frutas y verduras
        /// </summary>
        /// <returns>Objeto tipo JSON con el listado de productos</returns>
        // POST: api/GetNamesProduct
        public IHttpActionResult GetNamesProduct()
        {
            this.product = new ControlGetProduct();
            return Ok(this.product.getNamesProducts());
        }

    }
}
