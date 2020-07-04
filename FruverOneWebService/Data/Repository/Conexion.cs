using Data.ControlRepository;
using Npgsql;
using System;


namespace Data.Repository
{
    public class Conexion : IConexion
    {//Parámetros necesarios para realizar la conexion a la base de datos:
        private const string server = "localhost";
        private const string port = "5430";
        private const string userId = "postgres";
        private const string password = "12345";
        private const string dataBase = "postgres";


        //Objeto que permite realizar la conexión a la base de datos con PostgreSQL
        readonly NpgsqlConnection conexionDb;

        public Conexion()
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
             string parametros = $"Server={server};Port={port}; User Id={userId};Password={password};Database={dataBase}";
            //string password = "12345"; // su contraseña
            //string nameDB = "postgres";   // nombre de la base de datos
            
           // string parametros = "Server=localhost; Port=5430; User Id=postgres; Password=" + password + "; Database=" + nameDB;
            conexionDb.ConnectionString = parametros;

            try
            {
                conexionDb.Open();

                return conexionDb;
            }
            catch (Exception error) {
                Console.WriteLine("Error en la conexión "+error.Message);
                return null;
                //throw new Exception("Error en al conexión");
            }



          
        }

    }
}
