using FruverOneWebClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FruverOneWebClient.Controllers
{

    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        // POST: Login/Create
        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginUser(UserAccountTemplate userCredentials)
        {
            try
            {
                // TODO: Add insert logic here
                string urlWebService = $"http://localhost:63659/api/Login";
                string method = "POST";
                //Se envia la petición al Web Service solicitando los datos del usuario creado
                var responseServer = RequestAPI.Request.Send<UserAccountTemplate>(urlWebService,userCredentials);
                var responseJSON = responseServer.Data.ToString();
                UserAccountTemplate userAccountModel = JsonConvert.DeserializeObject<UserAccountTemplate>(responseJSON.ToString());

                //Serializamos la cadena JSON recibida por el web service en un objeto tipo CustomerTemplate
                if (userAccountModel.Status == 200)
                {
                    userAccountModel = JsonConvert.DeserializeObject<UserAccountTemplate>(userAccountModel.Data.ToString());
                    Session["User"] = userAccountModel;
                    FormsAuthentication.SetAuthCookie(userAccountModel.Email, true);
                    ViewBag.Message = "Bienvenido"; 
                    return RedirectToAction("Frutas","Product", new { });
                    
                }
                else
                {
                    ViewBag.Message = "Datos De Acceso Incorrectos";
                    return Index();
                }
                
            }
            catch
            {
                ViewBag.Message = "Error interno en el servicio, por favor, intente más tarde";
                return Index();
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Index");
        }

    }
}
