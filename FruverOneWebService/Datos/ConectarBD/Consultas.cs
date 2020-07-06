using System;
using System.Collections.Generic;
using System.Text;
using Datos.Interfaz;
using Datos.NewFolder;
using Npgsql;

namespace Datos.ConectarBD
{
    public class Consultas
    {
        private readonly Conexion conectar;

        public Consultas()
        {
            conectar = new ConexionPostgre();
        }

        public bool ConsultaBD (string query)
        {
            try
            {
                //conectar a la base de datos 
                var conectarBD = conectar.ConectarBaseDatos();
                NpgsqlCommand comando = new NpgsqlCommand(query, conectarBD);
                comando.ExecuteNonQuery(); // ejecuta la consulta a la BD
                return true;

            }
            catch (Exception)
            {
                Console.WriteLine("Error Al Insertar Un Dato");
                return false;
            }        
        }

        public bool InsertarProducto(string query) => this.ConsultaBD(query);

    }
}
