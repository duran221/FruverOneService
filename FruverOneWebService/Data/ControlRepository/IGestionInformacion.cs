using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.ControlRepository
{
    interface IGestionInformacion
    {

        bool actualizar(String query);
        bool eliminar(String query);
        bool insertar(String query);

        //Json consulta(String query);

    }
}
