using System;
using System.Collections.Generic;
using System.Text;
using Datos.Interfaz;
using Npgsql;

namespace Datos.NewFolder
{
    public class ConexionPostgre : Conexion
    {
        // Parametros para la conexion a la base de datos 
        private const string servidor= "localhost";
        private const string puerto = "5432";
        private const string usuarioId = "postgres";
        private const string contraseña = "9294";
        private const string nombreBD = "FruverOne";

        
        private readonly NpgsqlConnection conexionDb;
        public ConexionPostgre()
        {
            conexionDb = new NpgsqlConnection();
        }

        /// <summary>
        /// Cierra una conexión a la base de datos 
        /// </summary>
        public void CerrarConcexion()
        {
            throw new NotImplementedException();
        }

       
        /// <summary>
        /// Genera  la conexión a la base de datos de postgres
        /// </summary>
        /// <returns>Objeto con la conexión a Postgre</returns>
        public NpgsqlConnection ConectarBaseDatos()
        {
            string parametros = $"Server={servidor};Port={puerto};User Id={usuarioId};Password={contraseña};Database={nombreBD}";
            conexionDb.ConnectionString = parametros;
            try
            {
                conexionDb.Open();

            }
            catch (Exception)
            {

                Console.WriteLine("Error en la conexión");

            }

            return conexionDb;
        }


    }
}
