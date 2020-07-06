using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Control;
using Newtonsoft.Json.Linq;

namespace APIFruverOne.Controllers
{
    public class RegistrarProductoApiController : ApiController
    {
        private readonly ControlRegistrarProducto controlRegistro;


        public RegistrarProductoApiController()
        {
            controlRegistro = new ControlRegistrarProducto();
        }
        // GET: api/RegistrarProductoApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RegistrarProductoApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RegistrarProductoApi
        public bool Post(JObject producto)
        {
            return controlRegistro.RegistrarProducto(producto);
        }

        // PUT: api/RegistrarProductoApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RegistrarProductoApi/5
        public void Delete(int id)
        {
        }
    }
}
