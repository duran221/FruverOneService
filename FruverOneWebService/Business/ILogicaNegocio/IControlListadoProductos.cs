using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.EntidadesDelDominio.Entidades;

namespace Business.ControlRepositorio
{
    public interface IControlListadoProductos
    {
        List<Producto> ListarProductos();
        bool EliminarProducto(String COD);
        bool ActualizarProducto(String COD, String Nombre, String Descripcion, int Cantidad, float Precio);
    }
}
