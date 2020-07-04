using APIFruverOne.APIRestService;
using APIFruverOne.IServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIFruverOne.Controllers
{
    public class ListarProductosController : ApiController
    {
        readonly IControllerListarProductos control = new ControlListarProducto();
      

        // GET: api/ListarProductos
        [HttpGet]
        public List<JObject> ListarProductos()
        {
            return control.listadoProdutos();
        }


        // POST: api/ActualziarProducto
       /* [HttpPost]
        public bool ActualizarProducto(String name)
        {
            return true;
        }*/

        // DELETE: api/EliminarProducto
        [HttpDelete]
        public bool Delete(String COD)
        {
            return control.eliminarProducto(COD);
        }
    }
}
