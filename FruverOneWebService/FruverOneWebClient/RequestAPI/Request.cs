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
        /// 
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
        /// 
        /// </summary>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        private static string LeerArchivo(HttpWebResponse httpResponse)
        {
            string result;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }

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
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private static WebRequest  EscribirArchivo(string json, WebRequest request)
        {
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                //Cerrando la escritura del archivo:
                streamWriter.Flush();
            }

            return request;
        }
    }
}