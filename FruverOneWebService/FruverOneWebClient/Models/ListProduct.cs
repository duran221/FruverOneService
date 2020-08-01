using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace FruverOneWebClient.Models
{
    public class ListProduct
    {
        public String respuesta;
        public List<Product> lista;

        public ListProduct(String type) {
            this.respuesta = GetHttp(type);
            this.construirLista();
        }
        public void construirLista()
        {
            List<Product> lst = JsonConvert.DeserializeObject<List<Product>>(this.respuesta);
            this.lista = lst;
        }
        public string GetHttp(String type)
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44304/api/GetListProduct?typeProduct="+type);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return sr.ReadToEnd();

        }
    }
}