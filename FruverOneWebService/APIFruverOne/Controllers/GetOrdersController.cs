using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Control;
using Business.IControl;
using Domain.Class;

namespace APIFruverOne.Controllers
{
    public class GetOrdersController : ApiController
    {
        IControlGetOrders controlOrders;

        public GetOrdersController()
        {
            this.controlOrders = new ControlGetOrders();
        }
        // GET: api/GetOrders
        public IHttpActionResult Get(int idOrder)
        {
            Order order = this.controlOrders.GetOrder(idOrder);
            return Ok(order);

        }

        // GET: api/GetOrders
        public IHttpActionResult GetOrders()
        {
            List<Order> listOrders = this.controlOrders.GetOrders();
            return Ok(listOrders);

        }

        public IHttpActionResult GetOrderDetails(int idOfOrder)
        {
            List<OrderDetails> listOrderDetails = this.controlOrders.GetOrderDetails(idOfOrder);
            return Ok(listOrderDetails);

        }
    }
}
