using APIFruverOne.IServices;
using Domain.EntidadesDelDominio.Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFruverOne.APIRestService
{
    public class ControlListarProducto : IControllerListarProductos
    {

        readonly Business.ILogicaNegocio.IControlListadoProductos control;

        public ControlListarProducto() {
            control = new Business.ControlRepositorioNegocio.ControlListarProductos();
        }
        public bool actualizarProducto(string COD, string Nombre, string Descripcion, int Cantidad, float Precio)
        {
            return true;
        }

        public bool eliminarProducto(string COD)
        {
            bool resp = control.EliminarProducto(COD);
            return resp;
        }

        public List<JObject> listadoProdutos()
        {
            List<Producto> listProduct = control.ListarProductos();
            List<JObject> productosJSON = new List<JObject>();
            JObject datosList = new JObject();
          //  string listado = JsonConvert.SerializeObject(listProduct);

            
            for (int n=0; n<listProduct.Count; n++) {
               productosJSON.Add(
                    JObject.FromObject( new { 
                        
                        COD = listProduct[n].COD,
                        Nombre = listProduct[n].Nombre,
                        Descripcion = listProduct[n].Descripcion,
                        Cantidad = listProduct[n].Cantidad,
                        Precio = listProduct[n].Precio,
                        Total = listProduct[n].calcularTotalInventarioPesos()
                    })
                 );
            }



            return productosJSON;
            
        }
    }
}