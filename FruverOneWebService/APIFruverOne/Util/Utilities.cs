using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFruverOne.Util
{
    public static class Utilities
    {

        /// <summary>
        /// Permite armar una respuesta en formato JSON que será retornada a el cliente
        /// </summary>
        /// <typeparam name="T">Modelo generico que será almacenado en el campo data de la respuesta</typeparam>
        /// <param name="objectModel"></param>
        /// <param name="status">estado de respuesta de la solicitud</param>
        /// <returns>Objeto JSON con los campos que serán retornados a el cliente que realiza la solicitud</returns>
        public static JObject BuildResponse<T>(T objectModel,int status)
        {
                return JObject.FromObject(new
                {
                    status = status,
                    data = objectModel
                });
           
        }

    }
}