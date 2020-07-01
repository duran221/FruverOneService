using Data.ControlRepository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Repository
{
    class ControlRepositorio : IGestionInformacion
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
        private bool ConstruirConsulta(string query)
        {
            try
            {
                var conectDb = conection.ConnectDb();

                NpgsqlCommand command = new NpgsqlCommand(query, conectDb);
                
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
        public DataTable ResolveQuerySelect(string query)
        {
            DataSet datos = new DataSet();
            try
            {
                var conectDb = conection.ConnectDb();
                NpgsqlDataAdapter response = new NpgsqlDataAdapter(query, conectDb);
                response.Fill(datos);
              
                conection.CloseConectionDb();
                return datos.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
              
                return new DataTable();
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

        bool IGestionInformacion.ConstruirConsulta(string query)
        {
            throw new NotImplementedException();
        }
    }
}
