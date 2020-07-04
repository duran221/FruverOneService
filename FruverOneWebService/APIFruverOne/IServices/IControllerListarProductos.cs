using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFruverOne.IServices
{
    public interface IControllerListarProductos
    {

        bool eliminarProducto(String COD);
        bool actualizarProducto(string COD, string Nombre, string Descripcion, int Cantidad, float Precio);
        List<JObject> listadoProdutos();
    }
}
