using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIFruverOne.Controllers
{
    public class LoginController : ApiController
    {
       
        [HttpPost]
        // GET: api/Login/5
        public IHttpActionResult Get(JObject userCredentials)
        {
            try
            {
                return Ok("OK");
            }catch(Exception ex)
            {
                return null;

            }
        }

    }
}
