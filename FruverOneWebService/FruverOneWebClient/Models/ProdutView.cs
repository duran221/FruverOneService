using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace FruverOneWebClient.Models
{
    public class ProdutView
    {


        public ProdutView()
        {
        }
        /// <summary>
        /// Consultar información de producto
        /// </summary>
        /// <param name="name">nombre del producto</param>
        /// <returns>JSON con información del producto</returns>
        public string GetHttpProduct(String name) 
        {
            try {
                WebRequest oRequest = WebRequest.Create("https://localhost:44304/api/GetProduct?nameProduct=" + name);
                WebResponse oResponse = oRequest.GetResponse();
                StreamReader sr = new StreamReader(oResponse.GetResponseStream());
                return sr.ReadToEnd();
            }
            catch (IOException e) {

                String queryProd = @"{'message': 200}";
                JObject productJSON = JObject.Parse(queryProd);

                return productJSON.ToString();
            }
            

        }
    }
}