using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.ControlRepository
{
    interface IGestionInformacion
    {
        bool ConstruirConsulta(string query);
        DataTable ResolveQuerySelect(string query);
        bool InsertBD(string query);
        bool DeleteBD(string query);
        bool UpdateBD(string query);
    }
}
