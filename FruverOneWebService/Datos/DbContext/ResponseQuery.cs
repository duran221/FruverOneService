using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Interface;
using Npgsql;
using NpgsqlTypes;

namespace Datos.DbContext
{
    public class ResponseQuery
    {
        private readonly Conexion conection;


        public ResponseQuery()
        {
            //Inicia la conexión con la base de datos:
            conection = new DbContextPostgre();
        }


        /// <summary>
        /// Ejecuta una consulta de Carácter Insert,Update o Delete en la base de datos Postgres
        /// 
        /// </summary>
        /// <param name="query">Cadena con la consulta sql a ejecutar</param>
        /// <returns>Verdadero si la consulta se ejecutó con éxito, false de lo contrario</returns>
        private bool ResolveQuery(string query)
        {
            try
            {
                var conectDb=conection.ConnectDb();

                NpgsqlCommand command = new NpgsqlCommand(query,conectDb);
                //Ejecuta la consulta sql en la base de datos
                command.ExecuteNonQuery();
                //Cierro la conexión con la base de datos.
                conection.CloseConectionDb();
                return true;

            }
            catch (Exception)
            {
                Console.WriteLine("Error en la insersión");
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
                //Abrimos la conexión a la base de datos:
                var conectDb=conection.ConnectDb();

                //Ejecutamos la consulta que nos llega por parámetros:
                NpgsqlDataAdapter response = new NpgsqlDataAdapter(query,conectDb);

                //Almaceno en el objeto 'datos' los datos obtenidos de la consulta anterior:
                response.Fill(datos);
                //Cierro la conexión con la base de datos:
                conection.CloseConectionDb();
                return datos.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Retorna un objeto vacio para evitar complejidad en métodos superiores:
                return new DataTable();
            }

        }

        /// <summary>
        /// Ejecuta una consulta de carácter Insert en la base de datos
        /// </summary>
        /// <param name="query">Consulta sql a ejecutar</param>
        /// <returns>True si la insersión fué completada, false de lo contrario</returns>
        public bool ResolveQueryInsert(string query) => this.ResolveQuery(query);

        /// <summary>
        /// Ejecuta una consulta de carácter Delete en la base de datos
        /// </summary>
        /// <param name="query">>Consulta sql a ejecutar</param>
        /// <returns>True si la eliminación fué completada, false de lo contrario</returns>
        public bool ResolveQueryDelete(string query) =>  this.ResolveQuery(query);


        /// <summary>
        /// Ejecuta una consulta de carácter Update en la base de datos
        /// </summary>
        /// <param name="query">>Consulta sql a ejecutar</param>
        /// <returns>True si la eliminación fué completada, false de lo contrario</returns>
        public bool ResolveQueryUpdate(string query) =>  this.ResolveQuery(query);

    }
}
