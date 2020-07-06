using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clases
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }

        public string DescripcionProducto { get; set; }
        public double PrecioProducto { get; set; }
        public int IvaProducto { get; set; }


    }
}
