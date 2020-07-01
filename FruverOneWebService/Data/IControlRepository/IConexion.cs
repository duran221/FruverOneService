using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ControlRepository
{
    interface IConexion
    {
        /// <summary>
        /// Permite establecer una conexión a la base de datos PostgreSQL
        /// </summary>
        /// <returns></returns>
        NpgsqlConnection ConnectDb();

        /// <summary>
        /// Cierra la conexión actual con la base de datos.
        /// </summary>
        /// <returns></returns>
        void CloseConectionDb();

    }
}

