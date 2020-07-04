using Domain.EntidadesDelDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Data.ControlRepository;
using Npgsql;
using Business.ILogicaNegocio;

namespace Business.ControlRepositorioNegocio
{
    public  class ControlListarProductos : IControlListadoProductos
    {
        private IGestionInformacion conection = new Data.Repository.ControlRepositorio();
        private List<Producto> listaProductos = new List<Producto>();
        public ControlListarProductos() {
            conection = new Data.Repository.ControlRepositorio();
        }

        /// <summary>
        /// Actualiza un producto en la BD
        /// </summary>
        /// <param name="COD"></param>
        /// <param name="Nombre"></param>
        /// <param name="Descripcion"></param>
        /// <param name="Cantidad"></param>
        /// <param name="Precio"></param>
        /// <returns>True si fue exitosamente</returns>
        public bool ActualizarProducto(string COD, string Nombre, string Descripcion, int Cantidad, float Precio)
        {
            return true;
        }
        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name="COD">Del producto</param>
        /// <returns>True si fue exitosamente la eliminación del producto</returns>
        public bool EliminarProducto(string COD)
        {
            String query = "DELETE FROM PRODUCTOS WHERE COD='"+COD+"';";
            bool resp = conection.DeleteBD(query);

            return true;
        }
        /// <summary>
        /// Lista los productos que se encuentran registrados
        /// </summary>
        /// <returns>Listado de productos</returns>
        public List<Producto> ListarProductos()
        {
            String query = "SELECT * FROM PRODUCTOS;";

            NpgsqlDataReader datos = conection.ResolveQuerySelect(query);
            if (datos!=null) {
                while (datos.Read())
                {
                    String COD = datos[0].ToString().Trim();
                    String nombre = datos[1].ToString().Trim();
                    int cantidad = int.Parse(datos[2].ToString().Trim());
                    String descripcion = datos[3].ToString().Trim();
                    float precio = float.Parse(datos[4].ToString().Trim());
                    Producto productBD = new Producto(COD, nombre, descripcion, cantidad, precio);

                    listaProductos.Add(productBD);
                }
            }

            datos.Close();
            
            return listaProductos;
        }
        /// <summary>
        /// Calculamos el total de venta presupuestado para la tienda con los productos existentes
        /// </summary>
        /// <returns>Dinero en pesos</returns>
        public float Inventario() {
            float dinero = 0;

            for (int i=0; i< listaProductos.Count(); i++) {
                dinero += listaProductos[i].calcularTotalInventarioPesos();
            }
            return dinero;
        }


    }
}
