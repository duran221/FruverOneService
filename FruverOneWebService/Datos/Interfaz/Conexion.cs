using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;


namespace Datos.Interfaz
{
    interface Conexion
    {
        NpgsqlConnection ConectarBaseDatos();

        void CerrarConcexion();

    }
}
