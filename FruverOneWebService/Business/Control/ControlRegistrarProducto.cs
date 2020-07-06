using System;
using Datos.ConectarBD;
using Domain.Clases;
using Newtonsoft.Json.Linq;
namespace Business.Control

{
    public class ControlRegistrarProducto
    {

        Consultas query;

        public ControlRegistrarProducto()
        {
            query = new Consultas();

        }
        public bool RegistrarProducto(JObject Producto)
        {
            Producto producto = this.ModeloProducto(Producto);
            string comandoSql = "INSERT INTO public.\"producto\" VALUES" +
                                $"({producto.IdProducto},{producto.NombreProducto},{producto.DescripcionProducto},{producto.PrecioProducto}," +
                                $"{producto.IvaProducto})";
            bool registrar = query.InsertarProducto(comandoSql);
            return registrar;
        }

        private Producto ModeloProducto(JObject datosProducto)
        {
            return new Producto()
            {
                IdProducto = Int16.Parse(datosProducto["idProducto"].ToString()),
                NombreProducto = datosProducto["nombreProducto"].ToString(),
                DescripcionProducto = datosProducto["descripcionProducto"].ToString(),
                PrecioProducto = Int16.Parse(datosProducto["precioProducto"].ToString()),
                IvaProducto= Int16.Parse(datosProducto["ivaProducto"].ToString())
            };

        }

    }

}
