using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntidadesDelDominio.Entidades
{
    public class Producto
    {
        private String COD { get; }
        private String Nombre { get; }
        private String Descripcion { get; }
        private int Cantidad { get; }
        private float Precio { get; }

        public Producto(String COD, String Nombre, String Descripcion, int Cantidad, float Precio) {
            this.COD = COD;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
        }

        protected float calcularTotalInventarioPesos() {

            float inventario = this.Cantidad * this.Precio;
            return inventario;
        }
        


    }
}
