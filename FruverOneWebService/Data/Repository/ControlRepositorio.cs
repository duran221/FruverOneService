using Data.ControlRepository;
using Npgsql;
using System;

namespace Data.Repository
{
    public class ControlRepositorio : IGestionInformacion
    {
        private readonly Conexion conection;

        //Inicia la conexión con la base de datos:
        public ControlRepositorio()
        {
               conection = new Conexion();
        }


        /// <summary>
        /// Ejecuta una consulta de Carácter Insert,Update o Delete en la base de datos Postgres
        /// 
        /// </summary>
        /// <param name="query">Cadena con la consulta sql a ejecutar</param>
        /// <returns>Verdadero si la consulta se ejecutó con éxito, false de lo contrario</returns>
        public bool ConstruirConsulta(string query)
        {
            try
            {
              
                NpgsqlConnection conectionBD = conection.ConnectDb();

                NpgsqlCommand command = new NpgsqlCommand(query, conectionBD);
                command.ExecuteNonQuery();

                conection.CloseConectionDb(); 
                return true;

            }
            catch (Exception)
            {
                Console.WriteLine("Error en la ejecución de la consulta en la BD");
                return false;
            }

        }

        /// <summary>
        /// Ejecuta una consulta de Carácter Select en la base de datos, y retorna una Dataset con los 
        /// resultados de la consulta
        /// </summary>
        /// <param name="query">Cadena con la consulta Sql a Ejecutar</param>
        /// <returns>Conjunto de datos encontrados en la consulta sql</returns>
        public NpgsqlDataReader ResolveQuerySelect(string query)
        {

            NpgsqlConnection conectDb = conection.ConnectDb();
            try
            {

                NpgsqlDataAdapter response = new NpgsqlDataAdapter(query, conectDb);
                NpgsqlCommand comand = new NpgsqlCommand(query, conectDb);
                NpgsqlDataReader read = comand.ExecuteReader();
                
              ///  conection.CloseConectionDb();
                
                return read;
            }
            catch (Exception e) {
                Console.WriteLine("Error en la conexión"+ e.Message);
                return null;
            }


                
        }

        /// <summary>
        /// Ejecuta una consulta de carácter Insert en la base de datos
        /// </summary>
        /// <param name="query">Consulta sql a ejecutar</param>
        /// <returns>True si la insersión fué completada, false de lo contrario</returns>
        public bool InsertBD(string query) => this.ConstruirConsulta(query);

        /// <summary>
        /// Ejecuta una consulta de carácter Delete en la base de datos
        /// </summary>
        /// <param name="query">>Consulta sql a ejecutar</param>
        /// <returns>True si la eliminación fué completada, false de lo contrario</returns>
        public bool DeleteBD(string query) => this.ConstruirConsulta(query);


        /// <summary>
        /// Ejecuta una consulta de carácter Update en la base de datos
        /// </summary>
        /// <param name="query">>Consulta sql a ejecutar</param>
        /// <returns>True si la eliminación fué completada, false de lo contrario</returns>
        public bool UpdateBD(string query) => this.ConstruirConsulta(query);

    }
}
