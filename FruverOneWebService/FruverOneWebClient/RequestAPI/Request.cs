using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FruverOneWebClient.RequestAPI
{
    public static class Request
    {

        /// <summary>
        /// Genera y envia una solicitud http a el servicio web de la plataforma APIFruverOne
        /// </summary>
        /// <typeparam name="T">View Model que se va a enviar al web Service</typeparam>
        /// <param name="url">Dirección del servicio web al cual se realiza la petición</param>
        /// <param name="objectRequest">Objeto que se va a enviar a el web service para su posterior procesamiento</param>
        /// <param name="method">Indica el tipo de petición (Get o Post), por defecto se establece POST</param>
        /// <returns></returns>
        public static Response Send<T>(string url, T objectRequest, string method = "POST")
        {
            Response responseApi = new Response();
            try
            {
                
                //serializamos el objeto en una cadena JSON: 
                string json = JsonConvert.SerializeObject(objectRequest);

                WebRequest request = CrearRequest(url, method, json);
                //Se envia la petición http al web service y se obtiene una referencia de la respuesta:
                var httpResponse = (HttpWebResponse)request.GetResponse();

                string result = LeerArchivo(httpResponse);
                responseApi.Success = 200;
                //y aquí va nuestra respuesta, la cual es lo que nos regrese el sitio solicitado
                responseApi.Data = result;
            }
            catch (Exception e)
            {
                responseApi.Success = 0;
                //en caso de error lo manejamos en el mensaje
                responseApi.Message = e.Message;
            }

            return responseApi;
        }

        /// <summary>
        /// Lee y almacena en una cadena la respuesta devuelta por el servicio web
        /// </summary>
        /// <param name="httpResponse">Objeto http recibido como respuesta del servicio web</param>
        /// <returns>Cadena de texto con la respuesta del servicio</returns>
        private static string LeerArchivo(HttpWebResponse httpResponse)
        {
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }

        /// <summary>
        /// Crea una solicitud HttpRequest con los atributos necesarios para ser enviada al WebService
        /// </summary>
        /// <param name="url">dirección del servicio web al cual se realiza la petición</param>
        /// <param name="method">el tipo de petición que se realiza, puede ser GET,POST,PUT,DELETE</param>
        /// <param name="json">Cadena con la Información que se desea enviar al WebService</param>
        /// <returns></returns>
        private static WebRequest CrearRequest(string url, string method, string json)
        {
            //Instanciación del objeto que me permite realizar la petición a el web service (http).
            WebRequest request = WebRequest.Create(url);
            //headers
            request.Method = method;
            request.PreAuthenticate = true;
            request.ContentType = "application/json;charset=utf-8'";
            request.Timeout = 10000; //esto es opcional
                                     //Se escribe el objeto JSON en el objeto request:
            request= EscribirArchivo(json, request);

            return request;
        }

        
        /// <summary>
        /// Escribe la cadena JSON dentro de la solicitud Http que será enviada al WebService
        /// </summary>
        /// <param name="json">Cadena con los datos del objeto a incluir en la solicitud</param>
        /// <param name="request">Solicitud Http que será enviada al WebService</param>
        /// <returns>Solicitud Http con la información del Json contenido</returns>
        private static WebRequest  EscribirArchivo(string json, WebRequest request)
        {
            if (json != "null")
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    //Cerrando la escritura del archivo:
                    streamWriter.Flush();
                }
            }

            return request;
        }
    }
}