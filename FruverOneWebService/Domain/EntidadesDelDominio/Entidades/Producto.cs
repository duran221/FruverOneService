using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntidadesDelDominio.Entidades
{
    public class Producto
    {
        public String COD { get; }
        public String Nombre { get; }
        public String Descripcion { get; }
        public int Cantidad { get; }
        public float Precio { get; }

        public Producto(String COD, String Nombre, String Descripcion, int Cantidad, float Precio) {
            this.COD = COD;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
        }

        public float calcularTotalInventarioPesos() {

            float inventario = this.Cantidad * this.Precio;
            return inventario;
        }
        


    }
}
