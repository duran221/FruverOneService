using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Business.Control;
using Newtonsoft.Json.Linq;

namespace APIFruverOne.Controllers
{
    public class RegisterCustomerController : ApiController
    {
        private readonly ControlRegisterCustomer controlRegister;

        public RegisterCustomerController()
        {
            controlRegister = new ControlRegisterCustomer();
        }

        // GET: api/RegisterCustomer
        public bool Get()
        {
            return true;
        }

        // GET: api/RegisterCustomer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RegisterCustomer
        public bool Post(JObject dataCustomer)
        {
            var condition = controlRegister.RegisterCostumer(dataCustomer);
            return condition;
        }

        // PUT: api/RegisterCustomer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RegisterCustomer/5
        public void Delete(int id)
        {
        }
    }
}
