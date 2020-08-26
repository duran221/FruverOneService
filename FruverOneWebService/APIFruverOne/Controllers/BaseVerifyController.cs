using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Control;
using Business.IControl;

namespace APIFruverOne.Controllers
{
    public class BaseVerifyController : ApiController
    {
        readonly IControlAuthenticateUser controlLogin;

        public BaseVerifyController()
        {
            controlLogin = new ControlAuthenticateUser();
        }

        /// <summary>
        /// s
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool Verify(string token) => controlLogin.VerifyToken(token);
       
        
    }
}
