using Domain.EntidadesDelDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ControlRepositorio
{
    class ControlListarProductos : IControlListadoProductos
    {
        public bool ActualizarProducto(string COD, string Nombre, string Descripcion, int Cantidad, float Precio)
        {
            throw new NotImplementedException();
        }

        public bool EliminarProducto(string COD)
        {
            throw new NotImplementedException();
        }

        public List<Producto> ListarProductos()
        {
            List<Producto> listaProductos = new List<Producto>();








            return listaProductos;
        }
    }
}
