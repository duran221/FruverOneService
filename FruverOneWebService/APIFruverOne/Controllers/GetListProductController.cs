using Business.Control;
using System;
using System.Web.Http;

namespace APIFruverOne.Controllers
{
    public class GetListProductController : ApiController
    {
        private readonly ControlGetListProduct getList;
        public GetListProductController() {
            this.getList = new ControlGetListProduct();
        }
        /// <summary>
        /// Solicitud tipo GET para acceder a listado de frutas, vegetales o productos estrellas
        /// </summary>
        /// <param name="typeProduct"></param>
        /// <returns>Objeto tipo JSON</returns>
        // GET: api/GetListProduct
        public IHttpActionResult GetProducts(String typeProduct)
        {
            if (typeProduct.Equals("FRUTA")) {
                return Ok(getList.getFruties());
            } else if (typeProduct.Equals("VEGETAL")) {
                return Ok(getList.getVegetals());
            } else if (typeProduct.Equals("STAR")) {
                return Ok(getList.getStar());
            }
            return Ok("500");
        }
    }
}
