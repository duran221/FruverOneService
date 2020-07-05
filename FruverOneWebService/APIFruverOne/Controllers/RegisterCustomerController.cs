using System;
using System.Collections.Generic;
using System.Web.Http;
using Business.Control;
using Domain.Class;
using Newtonsoft.Json.Linq;

namespace APIFruverOne.Controllers
{
    public class RegisterCustomerController : ApiController
    {
        //Variables de instancia de las clases de control de la capa de Negocio:
        private readonly ControlRegisterCustomer controlRegister;
        private readonly ControlGetCustomer controlGetCustomer;

        public RegisterCustomerController()
        {
            controlRegister = new ControlRegisterCustomer();
            controlGetCustomer = new ControlGetCustomer();
        }



        /// <summary>
        /// Permite obtener información de todos los clientes (Customer) registrados en el sistema
        /// Ruta para acceso: GET: api/RegisterCustomer
        /// </summary>
        /// <returns></returns>
        public bool Get()
        {
            var costumers = controlGetCustomer.GetCustomers();
            return true;
        }


        // 
        /// <summary>
        /// Permite obtener la información de un cliente(Customer) especifíco usando como criterio su identificación
        /// Ruta para acceso: GET: api/RegisterCustomer/5
        /// </summary>
        /// <param name="documentCustomer">Documento de identificación del cliente (Customer)</param>
        /// <returns>JSON con la información del cliente solicitado</returns>
        public string Get(string documentCustomer)
        {
            Customer customer = controlGetCustomer.GetCustomer(documentCustomer);
            return "value";
        }


        /// <summary>
        /// Responde a una solicitud de registro de un cliente (Customer), gestiona el registro del usuario en la base de datos
        /// Ruta para accesar: api/RegisterCustomer
        /// </summary>
        /// <param name="dataCustomer">JSON con los datos del cliente (Customer) a registrar</param>
        /// <returns>Verdadero si el registro fué exitoso, Falso de lo contrario</returns>
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post(JObject dataCustomer)
        {
            var condition = controlRegister.RegisterCostumer(dataCustomer);

            return condition ? Ok("True"): Ok("False");
        }
      
    }
}
