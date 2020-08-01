using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Control;

namespace APIFruverOne.Controllers
{
    public class OrderController : ApiController
    {
        private readonly ControlOrden controlRegisterOrder;

        public OrderController ()
        {
            controlRegisterOrder = new ControlOrden();
        }


        // GET: api/Order
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        public bool Post(long document)
        {
            return controlRegisterOrder.RegisterOrder(document);
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
