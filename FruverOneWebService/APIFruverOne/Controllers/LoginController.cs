using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIFruverOne.Util;
using Business.IControl;
using Business.Control;
using Domain.Class;

namespace APIFruverOne.Controllers
{
    public class LoginController : BaseVerifyController
    {
        readonly IControlAuthenticateUser controlLogin;


        public LoginController()
        {
            this.controlLogin = new ControlAuthenticateUser();
        }
       
        [HttpPost]
        // GET: api/Login/5
        public IHttpActionResult Get(JObject userCredentials)
        {
            try
            {

                var loginModel = controlLogin.Login(userCredentials);
                return loginModel.Token != null ? Ok(Utilities.BuildResponse<UserAccount>(loginModel, 200)) : Ok(Utilities.BuildResponse<JObject>(null, 404));

            }
            catch(Exception ex)
            {
                return Ok(Utilities.BuildResponse<Exception>(ex,500));

            }
        }

    }
}
