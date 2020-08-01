using System;
using Datos.Interface;

//Import necesarios para la conexión a la base de datos de PostgreSQL.
using Npgsql;

namespace Datos.DbContext
{
    public class DbContextPostgre : IConexion
    {
        //Parámetros necesarios para realizar la conexion a la base de datos:
        private const string server = "localhost";
        private const string port = "5430";
        private const string userId = "postgres";
<<<<<<< HEAD
        private const string password = "9294";
        private const string dataBase = "FruverOne";
=======
        private const string password = "12345";
        private const string dataBase = "postgres";
>>>>>>> e90095af8d90d1403fda1c6e130038b1f1c878fd


        //Objeto que permite realizar la conexión a la base de datos con PostgreSQL
        private readonly NpgsqlConnection conexionDb;

        public DbContextPostgre()
        {
            conexionDb = new NpgsqlConnection();
        }

        /// <summary>
        /// Cierra una conexión activa con la base de datos:
        /// </summary>
        public void CloseConectionDb()
        {
            this.conexionDb.Close();    

        }

        /// <summary>
        /// Establece la conexión con la base de datos Postgre SQL
        /// </summary>
        /// <returns>Objeto con la conexión a PostgreSQL</returns>
        public NpgsqlConnection ConnectDb()
        {
            string parametros = $"Server={server};Port={port};User Id={userId};Password={password};Database={dataBase}";
            conexionDb.ConnectionString = parametros;
            try
            {
                conexionDb.Open();
                
            }catch (Exception)
            {

                Console.WriteLine("Error en la conexión");

            }

            return conexionDb;
        }

        
    }
}
