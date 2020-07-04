using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace APIFruverOne.Models
{
    public class ListaProductos
    {

        public String respuesta;
        public List<Producto> productos;
        public ListaProductos()
        {
            this.respuesta = GetHttp();
            construirLista();
        }

        public void construirLista() {
            List<Producto> lst = JsonConvert.DeserializeObject<List<Producto>>(this.respuesta);
            this.productos = lst;
        }


        public string GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44304/api/ListarProductos");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return sr.ReadToEnd();

        }
    }
}