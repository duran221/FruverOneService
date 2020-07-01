﻿using Data.ControlRepository;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class Conexion : IConexion
    {//Parámetros necesarios para realizar la conexion a la base de datos:
        private const string server = "localhost";
        private const string port = "5432";
        private const string userId = "postgres";
        private const string password = "6885";
        private const string dataBase = "FruverOne";


        //Objeto que permite realizar la conexión a la base de datos con PostgreSQL
        private readonly NpgsqlConnection conexionDb;

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
            string parametros = $"Server={server};Port={port};User Id={userId};Password={password};Database={dataBase}";
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

        NpgsqlConnection IConexion.ConnectDb()
        {
            throw new NotImplementedException();
        }
    }
}
