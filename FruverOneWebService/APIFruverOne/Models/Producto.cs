using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace APIFruverOne.Models
{
    public class Producto
    {
        public String COD { get; }
        public String Nombre { get; }
        public String Descripcion { get; }
        public int Cantidad { get; }
        public float Precio { get; }
        public float Total { get;  }

        public Producto(String COD, String Nombre, String Descripcion, int Cantidad, float Precio, float Total)
        {
            this.COD = COD;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Total = Total;
        }
       

    }
}