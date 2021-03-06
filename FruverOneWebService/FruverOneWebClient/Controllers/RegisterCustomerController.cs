﻿using FruverOneWebClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;
using FruverOneWebClient.Util;

namespace FruverOneWebClient.Controllers
{
    [Authorize]
    public class RegisterCustomerController : Controller
    {
        [AllowAnonymous]
        /// <summary>
        /// Permite mostrar la Página inicial con el formulario de registro de usuario
        /// Ruta para accesar:GET: RegisterCustomer
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
            {

            return View("RegisterCustomer");
        }


        /// <summary>
        /// Permite mostrar la información del cliente (Customer) en una vista HTML
        /// Ejemplo ruta para accesar: GET: RegisterCustomer/Details/5
        /// </summary>
        /// <param name="documentCustomer">Número de identificación del cliente (Customer)</param>
        /// <returns>Vista con los detalles del cliente Registrado</returns>
        public ActionResult Details(string documentCustomer)
        {

            string urlWebService = $"http://localhost:63659/api/RegisterCustomer?documentCustomer={documentCustomer}";
            string method = "GET";
            //Se envia la petición al Web Service solicitando los datos del usuario creado
            var responseServer = RequestAPI.Request.Send<JObject>(urlWebService, null,method);
            string codeResponse = responseServer.Data.ToString();
            //Serializamos la cadena JSON recibida por el web service en un objeto tipo CustomerTemplate
            CustomerTemplate customerModel= JsonConvert.DeserializeObject<CustomerTemplate>(codeResponse);
            return View("DetailsCustomer",customerModel);
        }


        /// <summary>
        /// Permite Registrar un cliente (Customer en el sistema para lo cual realiza una petición a el Servicio
        /// Web para que este realice la operación de dar de alta a el usuario en la base de datos
        /// Ruta para accesar: POST: RegisterCustomer/Create
        /// </summary>
        /// <param name="customer">Objeto con los atributos diligenciados por el Cliente en el formulario web</param>
        /// <returns>Si la inserción es correcta, retorna la Vista con los detalles del Cliente, de lo contrario, recarga el formulario de inserción</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(CustomerTemplate customer)
        {
            try
            {
                const string urlWebService= "http://localhost:63659/api/RegisterCustomer/";
                //Cifre la contraseña en SHA256
                customer.Password = Encrypt.EncryptSHA256(customer.Password);
                var responseServer = RequestAPI.Request.Send<CustomerTemplate>(urlWebService, customer);
                string codeResponse = responseServer.Data.ToString().Replace("\"","");
                if (codeResponse.Equals("200"))
                {
                    ViewBag.Message = "El registro ha sido exitoso";
                    return Details(customer.Document);
                }
                else
                {
                    ViewBag.Message = "El registro no creado, aségurese de que su email no esté previamente registrado o que su documento";
                    return Index();
                }        
            }
            catch
            {
                ViewBag.Message = "Ha ocurrido un error durante el registro, por favor intente de nuevo";
                return Index();
            }
        }
    
    }
}
