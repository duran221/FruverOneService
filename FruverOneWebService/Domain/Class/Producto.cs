using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Class
{
    public class Producto
    {

        public Producto()
        {

        }

        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public int precioProducto { get; set; }
        public int ivaProducto { get; set; }




    }
}
